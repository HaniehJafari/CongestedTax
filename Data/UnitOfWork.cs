namespace Data
{
	public class UnitOfWork : Base.UnitOfWork, IUnitOfWork
	{

		public UnitOfWork(Tools.Options options) : base(options)
		{
		}

		
		private IMaximumDailyTaxRepository _maximumDailyTaxRepository;

		public IMaximumDailyTaxRepository MaximumDailyTaxRepository
		{
			get
			{
				if (_maximumDailyTaxRepository == null)
				{
					_maximumDailyTaxRepository =
						new MaximumDailyTaxRepository(DatabaseContext);
				}

				return _maximumDailyTaxRepository;
			}
		}
		// **************************************************

		private ITollFeesRepository _tollFeesRepository;

		public ITollFeesRepository TollFeesRepository
		{
			get
			{
				if (_tollFeesRepository == null)
				{
					_tollFeesRepository =
						new TollFeesRepository(DatabaseContext);
				}

				return _tollFeesRepository;
			}
		}
		// **************************************************

		private ITollFreeDatesRepository _tollFreeDatesRepository;

		public ITollFreeDatesRepository TollFreeDatesRepository
		{
			get
			{
				if (_tollFreeDatesRepository == null)
				{
					_tollFreeDatesRepository =
						new TollFreeDatesRepository(DatabaseContext);
				}

				return _tollFreeDatesRepository;
			}
		}
		// **************************************************

		private ITollFreeVehiclesRepository _tollFreeVehiclesRepository;

		public ITollFreeVehiclesRepository TollFreeVehiclesRepository
		{
			get
			{
				if (_tollFreeVehiclesRepository == null)
				{
					_tollFreeVehiclesRepository =
						new TollFreeVehiclesRepository(DatabaseContext);
				}

				return _tollFreeVehiclesRepository;
			}
		}
		// **************************************************

	}
}
