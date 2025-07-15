using TheGuiXeCho.Web.Entity;

namespace TheGuiXeCho.Web.Interface
{
    public interface IVehiclesService
    {
        Task<bool> MotorbikeAdd(string plate, string VehicleType, DateTime timeIn, CancellationToken cancellation = default);
        Task<IEnumerable<Vehicles>> GetAll(CancellationToken cancellation = default);
        Task<Vehicles?> ConfirmMotorbike(int id, CancellationToken cancellation = default);
        Task<Vehicles?> GetVehicleById(int id, CancellationToken cancellationToken = default);
    }
}
