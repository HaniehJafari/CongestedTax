using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TaxController : Infrastructure.BaseApiController
	{
		public TaxController(Business.ICalculateTax calulateTax) : base()
		{
			CalulateTax = calulateTax;
		}
		protected Business.ICalculateTax CalulateTax { get; }
		[Microsoft.AspNetCore.Mvc.HttpPost("GetTaxAsync")]
		public
		Microsoft.AspNetCore.Mvc.ActionResult<int>
			GetTax(ViewModels.TaxInputsViewModel taxInputs)
		{
			int totalfee = CalulateTax.GetTax(taxInputs.VehicleType, taxInputs.dates);


			return Ok(value: totalfee);
		}
	}
}
