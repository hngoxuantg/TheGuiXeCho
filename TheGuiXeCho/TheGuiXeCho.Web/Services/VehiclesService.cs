using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TheGuiXeCho.Web.Data;
using TheGuiXeCho.Web.Entity;
using TheGuiXeCho.Web.Interface;
namespace TheGuiXeCho.Web.Services
{
    public class VehiclesService : IVehiclesService
    {
        private readonly TheGuiXeChoDbContext dbContext;
        public VehiclesService(TheGuiXeChoDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<bool> MotorbikeAdd(string plate, string VehicleType, DateTime timeIn)
        {
            Vehicles vehicles = new Vehicles
            {
                Id = 0,
                PlateNumber = plate,
                VehicleType = VehicleType,
                TimeIn = timeIn,
                TimeOut = null
            };
            dbContext.Vehicles.Add(vehicles);
            await dbContext.SaveChangesAsync();
            return true;
        }
        public async Task<IEnumerable<Vehicles>> GetAll()
        {
            return await dbContext.Vehicles.ToListAsync();
        }
    }
}
