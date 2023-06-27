using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppForManagers1._0.ViewModels;

namespace WpfAppForManagers1._0.Commands
{
    public class SubmitMechanicCommand : CommandBase
    {   public CreateMechanicViewModel MechanicViewModel { get; }

        public SubmitMechanicCommand(CreateMechanicViewModel mechanicViewModel )
        {
            MechanicViewModel = mechanicViewModel;
            MechanicViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public void OnViewModelPropertyChanged(object sender,PropertyChangedEventArgs args)
        {
            if(args.PropertyName == nameof(MechanicViewModel.FirstName))
            {
                OnCanExecuteChanged();
            }

        }
     

        public override void Execute(object? parameter)
        {
        }
    }
}
