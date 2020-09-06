using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using ToDoPhoneBook.Core.Services.ToDoService;
using ToDoPhoneBook.Domain.Entites;
using ToDoPhoneBook.Infrastructure;
using ToDoPhoneBook.Infrastructure.Mapping;
using ToDoPhoneBook.Infrastructure.Repositories;
using ToDoPhoneBook.Infrastructure.Repositories.Base;
using ToDoPhoneBook.Infrastructure.Tools;

namespace ToDoPhoneBool
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>
                (o => o.UseSqlServer(Configuration.GetConnectionString("Database")));

            services.AddTransient<IToDoItemsRepository, ToDoItemsRepository>();
            services.AddTransient<IToDoService, ToDoService>();



            var mapperConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mapperConfig.CreateMapper();
            
            services.AddSingleton(mapper);

            services.AddSingleton<ILoggerFactory, LoggerFactory>();
            services.AddSingleton(typeof(ILogger<>), typeof(Logger<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, AppDbContext db, ILoggerFactory loggerfactory)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            #region Создание БД, если она не создана, накат миграций, заполнение тестовыми данными

            db.Database.EnsureCreated();
            db.Database.Migrate();
            DbSeeder.Seed(db);

            #endregion

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=ToDo}/{action=Index}/{id?}");
            });
        }
    }
}
