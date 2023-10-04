using Microsoft.EntityFrameworkCore;
using TravelExpertManagement.BLL.Interfaces;
using TravelExpertManagement.BLL.Repositories;
using TravelExpertManagement.Data.Models;

namespace TravelExpertManagement.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddAuthentication("Cookies").AddCookie(
                opt => opt.LoginPath = "/Account/Login");

            builder.Services.AddSession();

            // Add services to the container.
            builder.Services.AddControllersWithViews();


            builder.Services.AddDbContext<TravelExpertsContext>(options =>
           options.UseSqlServer(
               builder.Configuration.GetConnectionString("DefaultConnection")));

            builder.Services.AddScoped<IPackageRepository, PackageRepository>();
            builder.Services.AddScoped<ICustomerRepository, CustomerRepository>();
            builder.Services.AddScoped<IBookingRepository, BookingRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStatusCodePages();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}