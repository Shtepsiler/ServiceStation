using Application.DTOs.Respponces;
using Application.Interfaces;
using Microsoft.IdentityModel.Abstractions;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppForManagers1._0.Commands;
using WpfAppForManagers1._0.Models;
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.Stores;
using WpfAppForManagers1._0.ViewModels.ClientViewsModels;
using WpfAppForManagers1._0.ViewModels.JobsViewModels;
using WpfAppForManagers1._0.ViewModels.MechanicsViewsModels;

namespace WpfAppForManagers1._0.ViewModels
{
    public class JobsForTodayViewModel : ViewModelBase
    {

        public ICommand navigateToManagers { get; set; }
        public ICommand navigateToCliens { get; set; }
        public ICommand navigateToJobs { get; set; }
     

        public ICommand navigateToMechanics { get; set; }

        private readonly IJobService jobService;


       
        public JobsForTodayViewModel(IJobService jobService,
            NavigationService<CreateMechanicViewModel> navtomechanics,
            NavigationService<ClientControlViewModel> navtoclients,
            NavigationService<MechanicControlViewMoidel> navtomech, 
            NavigationService<JobControlViewModel> navtojobs
            )
        {          
            jobs = new ObservableCollection<JobViewModel>();
            navigateToManagers = new NavigateCommand<CreateMechanicViewModel>(navtomechanics);
            navigateToCliens = new NavigateCommand<ClientControlViewModel>(navtoclients);
            navigateToMechanics = new NavigateCommand<MechanicControlViewMoidel>(navtomech);
            navigateToJobs = new NavigateCommand<JobControlViewModel>(navtojobs);
          ;
            this.jobService = jobService;
            jobViewModels = (IEnumerable<JobViewModel>)jobs;
         
            GetAllJobs();

        }

public  ObservableCollection<JobViewModel> jobs { get; set; }

        public async void GetAllJobs()
        {
            var models = await jobService.GetByIssueDateAsync(DateTime.Now);
           foreach(JobDTO model in models)
            {
                jobs.Add(new JobViewModel(model));


            }
        }
        

        public IEnumerable<JobViewModel> jobViewModels { get; set; } 
    }
}
