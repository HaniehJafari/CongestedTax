namespace Data
{
	public interface ITollFreeDatesRepository : Base.IRepository<Models.TollFreeDates>
	{
		bool IsTollFreeDate(System.DateTime date);

	}
}
