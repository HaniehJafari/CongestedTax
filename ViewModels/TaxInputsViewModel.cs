using System;
using System.Collections.Generic;
using System.Text;

namespace ViewModels
{
	public class TaxInputsViewModel : object
	{
		public TaxInputsViewModel() : base()
		{
		}
		public string VehicleType { get; set; }
		public DateTime[] dates { get; set; }

	}
}