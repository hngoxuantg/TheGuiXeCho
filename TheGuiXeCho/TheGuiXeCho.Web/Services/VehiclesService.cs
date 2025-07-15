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
        public async Task<bool> MotorbikeAdd(string plate, string VehicleType, DateTime timeIn, CancellationToken cancellation = default)
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
            await dbContext.SaveChangesAsync(cancellation);
            return true;
        }
        public async Task<IEnumerable<Vehicles>> GetAll(CancellationToken cancellation = default)
        {
            return await dbContext.Vehicles.ToListAsync(cancellation);
        }
        public async Task<Vehicles?> ConfirmMotorbike(int id, CancellationToken cancellation = default)
        {
            Vehicles? vehicles = await dbContext.Vehicles.FindAsync(id, cancellation);
            vehicles.TimeOut = DateTime.Now;
            await dbContext.SaveChangesAsync();
            return vehicles;
        }
        public async Task<Vehicles?> GetVehicleById(int id, CancellationToken cancellationToken = default)
        {
            return await dbContext.Vehicles.Where(v => v.Id == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
        }
    }
}
