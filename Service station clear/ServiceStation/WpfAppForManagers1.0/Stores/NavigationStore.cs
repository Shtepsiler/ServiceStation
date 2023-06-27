using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppForManagers1._0.ViewModels;

namespace WpfAppForManagers1._0.Stores
{
    public class NavigationStore 
    {
        private ViewModelBase currentViewModel;
        public ViewModelBase CurrentViewModel { get; set; }


    }
}
