using Microsoft.Extensions.DependencyInjection;
using System;
using WpfAppForManagers1._0.Services;

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

            services.AddSingleton<MainViewModel>();

            return services;
        }



    }
}
