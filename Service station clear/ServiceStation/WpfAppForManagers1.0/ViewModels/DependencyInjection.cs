using Microsoft.Extensions.DependencyInjection;
using System;
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.Stores;

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
            services.AddSingleton<CreateMechanicViewModel>();
            services.AddSingleton<MainViewModel>();

            services.AddSingleton<NavigationService<CreateMechanicViewModel>>();
         services.AddSingleton<Func<CreateMechanicViewModel>>((s) => () => s.GetRequiredService<CreateMechanicViewModel>());
         
            services.AddTransient<AllJobsViewModel>();
            services.AddSingleton<Func<AllJobsViewModel>>((s) => () => s.GetRequiredService<AllJobsViewModel>());
      services.AddSingleton<NavigationService<AllJobsViewModel>>();
            return services;
        }



    }
}
