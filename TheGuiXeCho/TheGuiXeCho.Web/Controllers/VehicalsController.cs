using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TheGuiXeCho.Web.Interface;

namespace TheGuiXeCho.Web.Controllers
{
    public class VehicalsController : Controller
    {
        private readonly IVehiclesService vehiclesService;
        public VehicalsController(IVehiclesService vehiclesService)
        {
            this.vehiclesService = vehiclesService;
        }
        public async Task<IActionResult> DanhSachXe()
        {
            return View(await vehiclesService.GetAll());
        }
        public IActionResult TaoXe()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> TaoXe(string plate, string vehicleType, DateTime timeIn)
        {
            if(await vehiclesService.MotorbikeAdd(plate, vehicleType, timeIn))
            {
                return RedirectToAction("DanhSachXe");
            }
            ModelState.AddModelError("", "Failed to add vehicle.");
            return RedirectToAction("DanhSachXe");
        }
    }
}
