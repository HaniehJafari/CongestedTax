using Microsoft.EntityFrameworkCore;

namespace Data.Base
{
	public abstract class UnitOfWork : object, IUnitOfWork
	{

		public UnitOfWork(Tools.Options options) : base()
		{
			Options = options;
		}

		protected Tools.Options Options { get; set; }
		
		private FintranetContext _databaseContext;

		internal FintranetContext DatabaseContext
		{
			get
			{
				if (_databaseContext == null)
				{
					var optionsBuilder =
						new DbContextOptionsBuilder<FintranetContext>();

					switch (Options.Provider)
					{
						case Tools.Enums.Provider.SqlServer:
						{
							optionsBuilder.UseSqlServer
								(connectionString: Options.ConnectionString);

							break;
						}

						case Tools.Enums.Provider.MySql:
						{
							//optionsBuilder.UseMySql
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Tools.Enums.Provider.Oracle:
						{
							//optionsBuilder.UseOracle
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Tools.Enums.Provider.PostgreSQL:
						{
							//optionsBuilder.UsePostgreSQL
							//	(connectionString: Options.ConnectionString);

							break;
						}

						case Tools.Enums.Provider.InMemory:
						{
							//optionsBuilder.UseInMemoryDatabase(databaseName: "Temp");

							break;
						}

						default:
						{
							break;
						}
					}

					_databaseContext =
						new FintranetContext(options: optionsBuilder.Options);
				}

				return _databaseContext;
			}
		}

		Repository<T> IUnitOfWork.GetRepository<T>()
		{
			return new Repository<T>(databaseContext: DatabaseContext);
		}

		public bool IsDisposed { get; protected set; }
		
		public void Dispose()
		{
			Dispose(true);

			System.GC.SuppressFinalize(this);
		}

		protected virtual void Dispose(bool disposing)
		{
			if (IsDisposed)
			{
				return;
			}

			if (disposing)
			{
				if (_databaseContext != null)
				{
					_databaseContext.Dispose();
					_databaseContext = null;
				}
			}

			IsDisposed = true;
		}

		~UnitOfWork()
		{
			Dispose(false);
		}
	}
}
