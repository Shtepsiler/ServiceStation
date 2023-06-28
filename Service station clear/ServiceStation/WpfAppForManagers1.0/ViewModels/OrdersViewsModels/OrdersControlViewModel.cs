using Application.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppForManagers1._0.Commands;
using WpfAppForManagers1._0.Models;
using WpfAppForManagers1._0.Services;

namespace WpfAppForManagers1._0.ViewModels.OrdersViewsModels
{
    public class OrdersControlViewModel : ViewModelBase
    {

        public ICommand navigateToHome { get; set; }



        public OrdersControlViewModel(NavigationService<JobsForTodayViewModel> navigationStore)
        {

            navigateToHome = new NavigateCommand<JobsForTodayViewModel>(navigationStore);




        }
    }
}
