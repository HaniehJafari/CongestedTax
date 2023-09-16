namespace Data.Base
{
	public interface IRepository<T> where T : class
	{
	
		T GetById(System.Guid id);

		System.Threading.Tasks.Task<T> GetByIdAsync(System.Guid id);


		System.Collections.Generic.IList<T> GetAll();

		System.Threading.Tasks.Task<System.Collections.Generic.IList<T>> GetAllAsync();
	}
}
