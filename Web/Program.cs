using Bussiness.services;
using Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddScoped<ClienteService>();
            builder.Services.AddScoped<ReservasService>();
            builder.Services.AddScoped<VehiculoService>();

            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<AppConection>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(name: "Cliente",
                            pattern: "{controller=Cliente}/{action=Crear}");
                
            // Prueba de conexi�n a la base de datos
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                try
                {
                    var context = services.GetRequiredService<AppConection>();
                    var count = context.EntityVehiculos.Count(); 
                    Console.WriteLine($"Conexi�n exitosa. Hay {count} veh�culo(s) en la base de datos.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error al conectar con la base de datos: {ex.Message}");
                }
            }


            app.Run();
        }
    }
}
