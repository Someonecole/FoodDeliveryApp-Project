using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace FoodDeliveryApp.Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }



        public List<Order> Orders { get; set; }
    }
}
