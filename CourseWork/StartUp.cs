using CourseWork.Data;
using CourseWork.Data.Interface;
using CourseWork.Data.Models;
using CourseWork.Data.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CourseWork
{
    public class StartUp
    {
        private IConfigurationRoot _confsting;

        public StartUp(IWebHostEnvironment hostEnv)
        {
            _confsting = new ConfigurationBuilder()
                .SetBasePath(hostEnv.ContentRootPath)
                .AddJsonFile("DbSettings.json", optional: true, reloadOnChange: true)
                .Build();

            var connectionString = _confsting.GetConnectionString("DefaultConnection");
            Console.WriteLine($"Connection String: {connectionString}");   
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<AppDBContent>(options =>
                options.UseSqlServer(_confsting.GetConnectionString("DefaultConnection")));

            services.AddTransient<IAllGame, GameRepository>();
            services.AddTransient<IGameCategory, CategoryRepository>();
            
            services.AddTransient<IAllOrders, OrdersRepository>();

            services.AddControllersWithViews();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped(sp => ShopGame.GetGames(sp));

            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();
            app.UseStaticFiles();

            app.UseSession();

            app.UseRouting();

            using (var scope = app.ApplicationServices.CreateScope())
            {
                var content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                DBObjects.Initial(content);
            }

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers(); // Для API-контроллеров
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"); // Для MVC
            });

            /*
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
                routes.MapRoute(name: "categoryFilter", template: "Games/{action}/{category?}", defaults: new { Controller = "Games", action = "List" }
                );
            });
            */
        }
    }
}