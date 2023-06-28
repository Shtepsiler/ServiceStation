using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfAppForManagers1._0.Commands;
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.Stores;

namespace WpfAppForManagers1._0.ViewModels.MechanicsViewsModels
{
    public class CreateMechanicViewModel : ViewModelBase
    {     
        public CreateMechanicViewModel(NavigationService<JobsForTodayViewModel> navigationStore, IMechanicService mechanicService)
        {
            SubmitCommand = new SubmitMechanicCommand(this, mechanicService, navigationStore);
            CancelCommand = new NavigateCommand<JobsForTodayViewModel>(navigationStore);
            GoHomeCommand = new NavigateCommand<JobsForTodayViewModel>(navigationStore);

        }
        public ICommand GoHomeCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }


        private string _firstname;
        public string FirstName
        {
            get { return _firstname; }
            set
            {
                _firstname = value;
                OnPropertyChanged(nameof(FirstName));
            }
        }
        private string _lastname;
        public string LastName
        {
            get { return _lastname; }
            set
            {
                _lastname = value;
                OnPropertyChanged(nameof(LastName));
            }
        }
        private string _address;
        public string Address
        {
            get { return _address; }
            set
            {
                _address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        private string _phone;
        public string Phone
        {
            get { return _phone; }
            set
            {
                _phone = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Phone));
            }
        }
        private string _specialization;





        public string Specialization
        {
            get { return _specialization; }
            set
            {
                _specialization = value;
                OnPropertyChanged(nameof(Specialization));
            }
        }


   


    }
}
