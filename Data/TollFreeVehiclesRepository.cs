using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Data
{
	public class TollFreeVehiclesRepository : Repository<Models.TollFreeVehicles>, ITollFreeVehiclesRepository
	{
		internal TollFreeVehiclesRepository(FintranetContext databaseContext) : base(databaseContext)
		{
		}

		public bool IsTollFreeVehicle(string vehicleType)
		{
			if (string.IsNullOrWhiteSpace(vehicleType))
			{
				return false;
			}


			var result =
				DbSet
				.Where(current => current.VehicleType.ToLower() == vehicleType.ToLower()).Any();
				

			return result;
		}

	}
}
