using BookStore.Data;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;


namespace BookStore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<BookService>();

            builder.Services.AddDbContext<ApplicationDbContext>(options =>
             options.UseSqlServer(
             builder.Configuration.GetConnectionString("DefaultConnection")));


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }



            app.Use(async (context, next) =>
            {
                Console.WriteLine("request Start");

                await next();

                Console.WriteLine("request Finished");

            });


            var appName = builder.Configuration["MySettings:AppName"];
            var version = builder.Configuration["MySettings:Version"];

            Console.WriteLine(appName);
            Console.WriteLine(version);




            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseAuthorization();

            app.MapStaticAssets();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}")
                .WithStaticAssets();



            app.Run();
        }
    }
}
