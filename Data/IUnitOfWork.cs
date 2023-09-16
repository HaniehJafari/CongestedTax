namespace Data
{
	public interface IUnitOfWork : Base.IUnitOfWork
	{
		// **********
		IMaximumDailyTaxRepository MaximumDailyTaxRepository { get; }
		ITollFeesRepository TollFeesRepository { get; }
		ITollFreeDatesRepository TollFreeDatesRepository { get; }
		ITollFreeVehiclesRepository TollFreeVehiclesRepository { get; }

	}
}
