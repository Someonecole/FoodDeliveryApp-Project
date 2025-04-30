using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryApp.ViewModels
{
    public class CustomerRegisterViewModel
    {
        // Име на клиента (задължително поле)
        [Required] 
        [StringLength(50)] // Определя максималната дължина на името (50 символа)
        public string CustomerName { get; set; }


        // Имейл адрес на клиента (задължително поле)
        [Required] 
        [EmailAddress] // Проверява дали въведената стойност е валиден имейл
        [StringLength(100)] // Ограничение на дължината на имейла до 100 символа
        public string Email { get; set; }

        // Парола на клиента (задължително поле)
        [Required] 
        [DataType(DataType.Password)] // Указва, че това поле съдържа парола (скрива символите)
        [StringLength(255)] // Определя максималната дължина на паролата (255 символа)
        public string Password { get; set; }

        // Телефонен номер на клиента (незадължително поле)
        [StringLength(15)] // Максимална дължина 15 символа (за международни номера)
        public string PhoneNumber { get; set; }

        // Адрес на клиента (незадължително поле)
        [StringLength(200)] // Максимална дължина 200 символа
        public string Address { get; set; }
    }

}
