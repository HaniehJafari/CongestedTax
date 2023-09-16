namespace Data
{
	public interface ITollFreeVehiclesRepository : Base.IRepository<Models.TollFreeVehicles>
	{
		bool IsTollFreeVehicle(string vehicleType);
	}
}
