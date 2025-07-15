using System.ComponentModel.DataAnnotations;

namespace TheGuiXeCho.Web.Entity
{
    public class Vehicles
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(15)]
        public string PlateNumber { get; set; }
        [Required, MaxLength(20)]
        public string VehicleType { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
    }
}
