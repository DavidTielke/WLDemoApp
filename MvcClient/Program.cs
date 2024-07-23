using DavidTielke.DemoApp.Data.DataStorage;
using DavidTielke.DemoApp.Logic.Business.BookingWorkflows;
using DavidTielke.DemoApp.Logic.Domain.BookingManagement;
using DavidTielke.DemoApp.Logic.Domain.ContactManagement;
using DavidTielke.DemoApp.Logic.Domain.EmailManagement;

namespace DavidTielke.DemoApp.UI.MvcClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            AddAppDependencies(builder.Services);

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

            app.Run();
        }

        private static void AddAppDependencies(IServiceCollection collection)
        {
            collection.AddTransient<IBookingWorkflow, BookingWorkflow>();
            collection.AddTransient<IBookingManager, BookingManager>();
            collection.AddTransient<IContactManager, ContactManager>();
            collection.AddTransient<IMailSender, MailSender>();
            collection.AddTransient<IBookingRepository, BookingRepository>();
            collection.AddTransient<IContactRepository, ContactRepository>();
        }
    }
}
