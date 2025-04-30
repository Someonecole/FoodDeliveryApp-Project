using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.ViewModels
{
    public class AdminLoginViewModel
    {
        // Задължително поле за имейл адреса на администратора
        [Required]
        [EmailAddress] // Проверява дали въведената стойност е валиден имейл адрес
        [StringLength(100)] // Ограничение на дължината на имейла до 100 символа
        public string Email { get; set; }

        // Задължително поле за паролата на администратора
        [Required]
        [DataType(DataType.Password)] // Указва, че това поле е парола (скрита при въвеждане)
        [StringLength(50)] // Ограничение на дължината на паролата до 50 символа
        public string Password { get; set; }
    }

}
