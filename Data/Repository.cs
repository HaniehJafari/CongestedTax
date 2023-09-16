//using System.Linq;
//using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class Repository<T> : Base.Repository<T> where T : class
	{
		internal Repository(FintranetContext databaseContext) : base(databaseContext)
		{
		}

	}
}
