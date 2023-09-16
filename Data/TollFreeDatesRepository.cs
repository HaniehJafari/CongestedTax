using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class TollFreeDatesRepository : Repository<Models.TollFreeDates>, ITollFreeDatesRepository
	{
		internal TollFreeDatesRepository(FintranetContext databaseContext) : base(databaseContext)
		{
		}

		public bool IsTollFreeDate(System.DateTime date)
		{
			if (date == null)
			{
				return false;
			}


			var result =
				DbSet
				.Where(current => current.Date.Date == date.Date).Any();
				

			return result;
		}

	}
}
