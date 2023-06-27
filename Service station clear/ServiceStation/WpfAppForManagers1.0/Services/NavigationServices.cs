using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppForManagers1._0.Stores;
using WpfAppForManagers1._0.ViewModels;

namespace WpfAppForManagers1._0.Services
{
    public class NavigationServices
    {
        private readonly NavigationStore navigationStore;
        private readonly Func<ViewModelBase> createViewmodel;

        public NavigationServices(NavigationStore navigationStore, Func<ViewModelBase> createViewmodel)
        {
            this.navigationStore = navigationStore;
            this.createViewmodel = createViewmodel;
        }


        public void Navigate()
        {
            navigationStore.CurrentViewModel = createViewmodel();
        }


    }
}
