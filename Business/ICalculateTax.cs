using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
	public interface ICalculateTax
	{
		int GetTax(string vehicleType, DateTime[] dates);
		bool IsTollFreeVehicle(string vehicleType);
		int GetTollFee(DateTime date, string vehicleType);
		bool IsTollFreeDate(DateTime date);
	}
}
