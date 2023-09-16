namespace Data
{
	public interface IMaximumDailyTaxRepository : Base.IRepository<Models.MaximumDailyTax>
	{
		int GetMaximumDailyTax();


	}
}
