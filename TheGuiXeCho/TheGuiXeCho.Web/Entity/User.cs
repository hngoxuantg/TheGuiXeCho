using System.ComponentModel.DataAnnotations;

namespace TheGuiXeCho.Web.Entity
{
    public class User
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string UserName { get; set; }
        [Required, MaxLength(255)]
        public string Password { get; set; }
        [MaxLength(70)]
        public string? FullName { get; set; }
    }
}
