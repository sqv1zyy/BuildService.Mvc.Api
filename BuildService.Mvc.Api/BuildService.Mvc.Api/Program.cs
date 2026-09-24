using BuildService.Mvc.Api.infrastructure;

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

            // функционал контроллеров
            builder.Services.AddControllersWithViews();

            // сборка конфигурации
            var app = builder.Build();

            // подключение использования статичных файлов
            app.UseStaticFiles();

            // подключение системы маршрутизации
            app.UseRouting();

            // регистрация маршрутов
            app.MapControllerRoute("default", "{controller=Home}/{action=Index/{id?}}");


            await app.RunAsync();
        }
    } 
}
