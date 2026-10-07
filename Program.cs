using BuildService.Mvc.Api.Domain;
using BuildService.Mvc.Api.Domain.Repositories;
using BuildService.Mvc.Api.Domain.Repositories.Abstract;
using BuildService.Mvc.Api.Domain.Repositories.EntityFramework;
using BuildService.Mvc.Api.infrastructure;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace BuildService.Mvc.Api
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // подключение в конфигурацию файла appsettings.json
            IConfigurationBuilder configBuild = new ConfigurationBuilder()
                .SetBasePath(builder.Environment.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            // делаю секцию Project объектной
            IConfiguration configuration = configBuild.Build();
            AppConfig config = configuration.GetSection("Project").Get<AppConfig>()!;

            // подключение контекст бд
            builder.Services.AddDbContext<AppDbContext>(options => options.UseNpgsql(config.DataBase.ConnectionString)
    .ConfigureWarnings(warnings => warnings.Ignore(RelationalEventId.PendingModelChangesWarning)));

            // функционал контроллеров
            builder.Services.AddControllersWithViews();

            // регистрация репозиториев
            builder.Services.AddTransient<IServicesCategoriesRepository, 
                EFServicesCategoriesRepository>();
            builder.Services.AddTransient<IServicesRepository, 
                EFServicesRepository>();
            builder.Services.AddTransient<DataManager>();

            // настройка Identity system
            builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // настройка куки аунтификации
            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "domstroi";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/admin/accessdenied";
                options.SlidingExpiration = true;
            });

            builder.Services.AddSwaggerGen();

            // сборка конфигурации
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            // подключение использования статичных файлов
            app.UseStaticFiles();

            // подключение системы маршрутизации
            app.UseRouting();

            // подключаю аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // регистрация маршрутов
            app.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            await app.RunAsync();
        }
    }
}