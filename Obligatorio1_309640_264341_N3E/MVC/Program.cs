using Microsoft.EntityFrameworkCore;


namespace MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

           
            builder.Services.AddControllersWithViews();

            // Habilitar sesiones
            builder.Services.AddSession();


            // Inyecciones de dependencias
            builder.Services.AddHttpClient();


            // DbContext



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            // Activar middleware de sesiones (ANTES de Authorization)
            app.UseSession();

            app.UseRouting();

            

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Usuario}/{action=Login}/{id?}");

            app.Run();
        }
    }
}
