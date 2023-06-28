using Microsoft.Extensions.DependencyInjection;
using System;
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.Stores;
using WpfAppForManagers1._0.ViewModels.ClientViewsModels;
using WpfAppForManagers1._0.ViewModels.JobsViewModels;
using WpfAppForManagers1._0.ViewModels.MechanicsViewsModels;
using WpfAppForManagers1._0.ViewModels.OrdersViewsModels;
using WpfAppForManagers1._0.ViewModels.PartsViewsModels;

namespace WpfAppForManagers1._0.ViewModels
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddViewsModels(this IServiceCollection services)
        {
            /*
                        services.AddTransient((s) => CreateReservationListingViewModel(s));
                        services.AddSingleton<Func<ReservationListingViewModel>>((s) => () => s.GetRequiredService<ReservationListingViewModel>());
                        services.AddSingleton<NavigationService<ReservationListingViewModel>>();

                        services.AddTransient<MakeReservationViewModel>();
                        services.AddSingleton<Func<MakeReservationViewModel>>((s) => () => s.GetRequiredService<MakeReservationViewModel>());
                        services.AddSingleton<NavigationService<MakeReservationViewModel>>();*/
            services.AddSingleton<NavigationStore>();
            services.AddSingleton<MainViewModel>();


     services.AddSingleton<CreateMechanicViewModel>();
        services.AddSingleton<NavigationService<CreateMechanicViewModel>>();
            services.AddSingleton<Func<CreateMechanicViewModel>>((s) => () => s.GetRequiredService<CreateMechanicViewModel>());

    services.AddSingleton<MechanicControlViewMoidel>();
        services.AddSingleton<NavigationService<MechanicControlViewMoidel>>();
            services.AddSingleton<Func<MechanicControlViewMoidel>>((s) => () => s.GetRequiredService<MechanicControlViewMoidel>());


    services.AddTransient<JobsForTodayViewModel>();
        services.AddSingleton<Func<JobsForTodayViewModel>>((s) => () => s.GetRequiredService<JobsForTodayViewModel>());
            services.AddSingleton<NavigationService<JobsForTodayViewModel>>();

    services.AddTransient<ClientControlViewModel>();
        services.AddSingleton<Func<ClientControlViewModel>>((s) => () => s.GetRequiredService<ClientControlViewModel>());
            services.AddSingleton<NavigationService<ClientControlViewModel>>();



    services.AddTransient<OrdersControlViewModel>();
        services.AddSingleton<Func<OrdersControlViewModel>>((s) => () => s.GetRequiredService<OrdersControlViewModel>());
            services.AddSingleton<NavigationService<OrdersControlViewModel>>();

    services.AddTransient<PartsControlViewModel>();
        services.AddSingleton<Func<PartsControlViewModel>>((s) => () => s.GetRequiredService<PartsControlViewModel>());
            services.AddSingleton<NavigationService<PartsControlViewModel>>();




            //Add jobs views models
    services.AddTransient<JobControlViewModel>();
        services.AddSingleton<Func<JobControlViewModel>>((s) => () => s.GetRequiredService<JobControlViewModel>());
            services.AddSingleton<NavigationService<JobControlViewModel>>();

    services.AddTransient<CreateJobViewModel>();
        services.AddSingleton<Func<CreateJobViewModel>>((s) => () => s.GetRequiredService<CreateJobViewModel>());
            services.AddSingleton<NavigationService<CreateJobViewModel>>(); 
            
    services.AddTransient<EditJobViewModel>();
        services.AddSingleton<Func<EditJobViewModel>>((s) => () => s.GetRequiredService<EditJobViewModel>());
            services.AddSingleton<NavigationService<EditJobViewModel>>();

            return services;
        }



    }
}
