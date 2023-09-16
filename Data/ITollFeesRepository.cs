namespace Data
{
	public interface ITollFeesRepository : Base.IRepository<Models.TollFees>
	{
		int GetAmountByTime(System.TimeSpan time);

	}
}
