﻿using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfAppForManagers1._0.ViewModels;
using Application;
using Infrastructure.Persistence.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Application.Interfaces;
using WpfAppForManagers1._0.Stores;

namespace WpfAppForManagers1._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : System.Windows.Application
    {
        private readonly IHost _host;

        public App()
        {
            _host = Host.CreateDefaultBuilder().
                ConfigureServices((hostContext, services) =>
               {                   
                   
                   services.AddApplication();
                   services.AddViewsModels();
                   services.AddDbContext<ServiceStationDContext>(options =>
                   {
                       string connectionString = hostContext.Configuration.GetConnectionString("MSSQLConnection");
                       options.UseSqlServer(connectionString);
                      
                   }, ServiceLifetime.Transient);

                   services.AddTransient<IServiceStationDContext, ServiceStationDContext>();
                   services.AddSingleton<NavigationStore>();

                   services.AddSingleton(s => new MainWindow()
                   {
                       DataContext = s.GetRequiredService<MainViewModel>()
                   });
               })
                .Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            NavigationStore navstore = _host.Services.GetRequiredService<NavigationStore>();
            navstore.CurrentViewModel = new MainViewModel(_host.Services.GetRequiredService<IJobService>(), _host.Services.GetRequiredService<NavigationStore>());
            _host.Start();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();
         MainWindow.Show();



            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            _host.Dispose();

            base.OnExit(e);
        }
    }
}
