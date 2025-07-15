using TheGuiXeCho.Web.Entity;

namespace TheGuiXeCho.Web.Interface
{
    public interface IVehiclesService
    {
        Task<bool> MotorbikeAdd(string plate, string VehicleType, DateTime timeIn);
        Task<IEnumerable<Vehicles>> GetAll();
    }
}
