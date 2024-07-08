using Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Service.Extensions;
using Entity.Services;
using Service.Services;
using AutoMapper;
using Service.Mapping;
using Entity.UnitOfWorks;
using Data.UnitOfWork;

namespace HotelReservation
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<HotelDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ConnStr")));

            // Eklenen servisler
            builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddExtensions();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "areas",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
            );

            app.MapControllerRoute(
                name: "area",
                pattern: "{controller=Home}/{action=Index}/{area=Admin}"
            );

            app.Run();
        }
    }
}
