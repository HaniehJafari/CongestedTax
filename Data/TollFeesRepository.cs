using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class TollFeesRepository : Repository<Models.TollFees>, ITollFeesRepository
	{
		internal TollFeesRepository(FintranetContext databaseContext) : base(databaseContext)
		{
		}
		
		public int GetAmountByTime(System.TimeSpan time)
		{
			if (time == null )
			{
				return 0;
			}

			var result2 =
				DbSet
				
				.FirstOrDefault();

			var result =
				DbSet
				//.Where(current => current.StartTime > time).Select(current => current.Amount)
				.Where(current => current.StartTime< time && current.EndTime>time ).Select(current=>current.Amount)
				.FirstOrDefault();

			return result;
		}

	}
}
