using FoodDeliveryApp.Data;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace FoodDeliveryApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Създаване на уеб приложението
            var builder = WebApplication.CreateBuilder(args);

            // Добавяне на поддръжка за контролери и изгледи (MVC)
            builder.Services.AddControllersWithViews();

            // Конфигуриране на Entity Framework Core с SQL Server
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
            );

            // Настройка на аутентикация с "Cookie-based" схема
            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = "/Home/Index"; // Път за страницата за вход
                    options.AccessDeniedPath = "/Home/AccessDenied"; // Път при отказан достъп
                });

            // Изграждане на приложението
            var app = builder.Build();

            // Проверка дали приложението НЕ е в режим на разработка
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error"); // Пренасочване към страница за грешки
                app.UseHsts(); // Активиране на HTTP Strict Transport Security (HSTS)
            }

            // Пренасочване на HTTP заявки към HTTPS
            app.UseHttpsRedirection();

            // Разрешаване на достъп до статични файлове (CSS, JavaScript, изображения и др.)
            app.UseStaticFiles();

            // Добавяне на маршрутизиране
            app.UseRouting();

            // Активиране на аутентикация и авторизация
            app.UseAuthentication();
            app.UseAuthorization();

            // Дефиниране на маршрути по подразбиране за MVC контролерите
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            // Стартиране на уеб приложението
            app.Run();
        }
    }

}
