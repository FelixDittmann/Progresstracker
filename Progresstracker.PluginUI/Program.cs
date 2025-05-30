using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Progresstracker.Application.DataObjectHandler;
using Progresstracker.Adapter;
using Progresstracker.PluginDatabase;
using Progresstracker.PluginUI;
using Progresstracker.Domain.Repository_Interfaces;
using Progresstracker.Adapter.Configuration.Progresstracker.Configuration;
using SQLitePCL;
using Microsoft.EntityFrameworkCore;


namespace Progresstracker.PluginUI
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            Batteries.Init();

            ApplicationConfiguration.Initialize();

            var host = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, config) =>
                {
                    config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
                })
                .ConfigureServices((context, services) =>
                {
                    AddConfigurationSettings(context, services);
                    AddDBContext(context, services);
                    AddServicesAndRepositories(context, services);

                    services.AddTransient<Mainwindow>();
                })
                .Build();

            var mainWindow = host.Services.GetRequiredService<Mainwindow>();
            System.Windows.Forms.Application.Run(mainWindow);
        }

        static void AddConfigurationSettings(HostBuilderContext context, IServiceCollection services)
        {
            services.AddSingleton<IConfiguration>(context.Configuration);
            services.AddSingleton<ConfigurationSettingsHandler>();
        }
        static void AddDBContext(HostBuilderContext context, IServiceCollection services)
        {
            services.AddDbContext<ProgressTrackerDatabaseContext>((provider, options) =>
            {
                var configHandler = provider.GetRequiredService<ConfigurationSettingsHandler>();
                options.UseSqlite(configHandler.DatabasePath);
            });
        }
        static void AddServicesAndRepositories(HostBuilderContext context, IServiceCollection services)
        {
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();
            services.AddScoped<IProfileService, ProfileService>();
            services.AddScoped<IProfileAdapter, ProfileAdapter>();
        }
    }
}