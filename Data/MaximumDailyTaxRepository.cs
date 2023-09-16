using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class MaximumDailyTaxRepository : Repository<Models.MaximumDailyTax>, IMaximumDailyTaxRepository
	{
		internal MaximumDailyTaxRepository(FintranetContext databaseContext) : base(databaseContext)
		{
		}

		public int GetMaximumDailyTax()
		{
			var result =
				DbSet.Select(current=>current.MaximumTaxValue)
				.FirstOrDefault();

			return result;
		}
	}
}
