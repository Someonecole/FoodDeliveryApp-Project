using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.Models
{
    public class Admin
    {
        [Key]
        public int AdminId { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Role { get; set; }
    }
}
