namespace Data.Base
{
	public interface IUnitOfWork : System.IDisposable
	{
		bool IsDisposed { get; }

		Repository<T> GetRepository<T>() where T : class;
	}
}
