﻿using Application.Interfaces;
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
using WpfAppForManagers1._0.ViewModels.JobsViewModels;

namespace WpfAppForManagers1._0.ViewModels.MechanicsViewsModels
{
    public class MechanicControlViewModel : ViewModelBase
    {
        public ICommand navigateToHome { get; set; }
        public ICommand navigateToCreateMechanic { get; set; }
        private readonly IMechanicService mechanicsService;

        public ICommand navigateToTasks { get; set; }



        public MechanicControlViewModel(IMechanicService clientsService, 
            NavigationService<JobsForTodayViewModel> toHome, 
            NavigationService<CreateMechanicViewModel> ctreatenav,
            NavigationService<GetTasksForJobViewModel> nawtotasks
            )
        {
            mechanics = new ObservableCollection<MechanicViewModel>();
            navigateToHome = new NavigateCommand<JobsForTodayViewModel>(toHome);
            navigateToCreateMechanic = new NavigateCommand<CreateMechanicViewModel>(ctreatenav);
            navigateToTasks = new NavigateCommand<GetTasksForJobViewModel>(nawtotasks);

            mechanicsService = clientsService;
            MechanicsViewModels = mechanics;


            GetAllJobs();

        }

        public ObservableCollection<MechanicViewModel> mechanics { get; set; }

        public async void GetAllJobs()
        {
            var users = await mechanicsService.GetAllAsync();
            foreach (var user in users)
            {
                mechanics.Add(new MechanicViewModel(user));


            }
        }


        public IEnumerable<MechanicViewModel> MechanicsViewModels { get; set; }


    }
}
