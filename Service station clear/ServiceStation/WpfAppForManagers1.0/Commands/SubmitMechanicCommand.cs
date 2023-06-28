using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.ViewModels;
using WpfAppForManagers1._0.ViewModels.MechanicsViewsModels;

namespace WpfAppForManagers1._0.Commands
{
    public class SubmitMechanicCommand : CommandBase
    {   public CreateMechanicViewModel MechanicViewModel { get; }
        
         private readonly IMechanicService MechanicService;
        private NavigationService<JobsForTodayViewModel> navtohome;

        public SubmitMechanicCommand(CreateMechanicViewModel mechanicViewModel, IMechanicService mechanicService, NavigationService<JobsForTodayViewModel> navigationStore)
        {
            MechanicViewModel = mechanicViewModel;
            MechanicService = mechanicService;
            MechanicViewModel.PropertyChanged += OnViewModelPropertyChanged;
            navtohome = navigationStore;
        }
        

        public void OnViewModelPropertyChanged(object sender,PropertyChangedEventArgs args)
        {
            if(args.PropertyName == nameof(MechanicViewModel.FirstName)  )
            {
                OnCanExecuteChanged();
            }

        }
     

        public override void Execute(object? parameter)
        {
            try
            {

                MechanicService.Create(new()
                {
                    FirstName = MechanicViewModel.FirstName,
                    LastName = MechanicViewModel.LastName,
                    Address = MechanicViewModel.Address,
                    Phone = MechanicViewModel.Phone,
                    Specialization = MechanicViewModel.Specialization,
                    Password = MechanicViewModel.Password
                });

            }
            catch ( Exception ex)
            {
                throw ex;

            }
            finally
            {
                navtohome.Navigate();
            }
        }
    }
}
