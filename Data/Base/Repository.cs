using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data.Base
{
	public class Repository<T> : object, IRepository<T> where T : class

	{
		internal Repository(FintranetContext databaseContext) : base()
		{

			DatabaseContext =
				databaseContext ?? throw new System.ArgumentNullException(paramName: nameof(databaseContext));

			DbSet = DatabaseContext.Set<T>();
		}

		internal FintranetContext DatabaseContext { get; }
		internal Microsoft.EntityFrameworkCore.DbSet<T> DbSet { get; }


		public virtual T GetById(System.Guid id)
		{
			return DbSet.Find(keyValues: id);
		}

		public virtual async System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id)
		{
			return await DbSet.FindAsync(keyValues: id);
		}

		public virtual System.Collections.Generic.IList<T> GetAll()
		{

			var result =
				DbSet.ToList()
				;

			return result;
		}

		public virtual async System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync()
		{

			var result =
				await
				DbSet.ToListAsync()
				;

			return result;

		}
	}
}
