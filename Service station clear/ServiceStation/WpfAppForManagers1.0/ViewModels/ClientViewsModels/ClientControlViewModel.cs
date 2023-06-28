using Application.DTOs.Respponces;
using Application.Interfaces;
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

namespace WpfAppForManagers1._0.ViewModels.ClientViewsModels
{
    public class ClientControlViewModel : ViewModelBase
    {
        public ICommand navigateToHome { get; set; }
        private readonly IClientsService clientsService;



        public ClientControlViewModel(IClientsService clientsService, NavigationService<JobsForTodayViewModel> navigationStore)
        {
            clients = new ObservableCollection<ClientViewModel>();
            navigateToHome = new NavigateCommand<JobsForTodayViewModel>(navigationStore);
            this.clientsService = clientsService;
            clientsViewModels = clients;


            GetAllClients();

        }

        public ObservableCollection<ClientViewModel> clients { get; set; }

        public async void GetAllClients()
        {
            var users = await clientsService.GetAllAsync();
            foreach (var user in users)
            {
                clients.Add(new ClientViewModel(user));


            }
        }


        public IEnumerable<ClientViewModel> clientsViewModels { get; set; }
    }
}
