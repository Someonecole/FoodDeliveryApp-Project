using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.ViewModels
{
    public class CustomerLoginViewModel
    {
        // Поле за имейл адреса на клиента (задължително)
        [Required] 
        [EmailAddress] // Проверява дали въведената стойност е валиден имейл адрес
        [StringLength(100)] // Ограничение на дължината на имейла до 100 символа
        public string Email { get; set; }


        // Поле за паролата на клиента (задължително)
        [Required]
        [DataType(DataType.Password)] // Указва, че полето е парола (скрива въведените символи)
        [StringLength(50)] // Ограничение на дължината на паролата до 50 символа
        public string Password { get; set; }
    }

}
