using System;
using System.Linq;
namespace Business
{
	public class CalculateTax : ICalculateTax
	{

		public CalculateTax(Data.IUnitOfWork unitOfWork) : base()
		{
			UnitOfWork = unitOfWork;
		}

		protected Data.IUnitOfWork UnitOfWork { get; }

		public int GetTax(string vehicleType, DateTime[] dates)
		{
			var sortedDates = dates.OrderBy(dt => dt);
			DateTime intervalStart = sortedDates.First();
			int totalFee = 0;
			int maximunDailyFee = UnitOfWork.MaximumDailyTaxRepository.GetMaximumDailyTax();
			foreach (DateTime date in sortedDates)
			{
				int nextFee = GetTollFee(date, vehicleType);
				int tempFee = GetTollFee(intervalStart, vehicleType);

				long diffInMillies =   (long)(date.Ticks / TimeSpan.TicksPerMillisecond - intervalStart.Ticks / TimeSpan.TicksPerMillisecond);
				long minutes = diffInMillies / 1000 / 60;

				if (minutes<=60 )
				{
					if (totalFee > 0) totalFee -= tempFee;
					if (nextFee >= tempFee) tempFee = nextFee;
					totalFee += tempFee;
					if (tempFee > 0)
						intervalStart = date;
				}
				else
				{
					totalFee += nextFee;
					intervalStart = date;
				}

			}
			if (totalFee > maximunDailyFee) totalFee = maximunDailyFee;
			return totalFee;
		}

	

		public bool IsTollFreeVehicle(string vehicleType)
		{
			bool isFree = UnitOfWork.TollFreeVehiclesRepository.IsTollFreeVehicle(vehicleType);
			return isFree;

		}

		public int GetTollFee(DateTime date, string vehicleType)
		{
			if (IsTollFreeDate(date) || IsTollFreeVehicle(vehicleType)) return 0;

			int tollFee = UnitOfWork.TollFeesRepository.GetAmountByTime(date.TimeOfDay);
			return tollFee;
		}

		public bool IsTollFreeDate(DateTime date)
		{
			bool isFree = UnitOfWork.TollFreeDatesRepository.IsTollFreeDate(date);
			return isFree;
		}


	}
}


//{
//	"vehicleType": "string",
//  "dates": [

//	"2023-09-16T21:06:30",
//  ]"2023-09-16T08:06:30",
//}
//"2023-09-16T16:06:30","2023-10-16T09:06:30"