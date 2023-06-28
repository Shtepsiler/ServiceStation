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
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.Stores;

namespace WpfAppForManagers1._0.ViewModels
{
    public class AllJobsViewModel : ViewModelBase
    {

        public ICommand navigaTeToManagers { get; set; }



        /*     public MainViewModel()
             {
                 jobs = new ObservableCollection<JobViewModel>();
                 jobs.Add(new JobViewModel(new() { Id = 1, ClientId = 1, MechanicId = 1, ModelId = 1, ManagerId = 1, Status = "pending", Description = "blablabla", Price = 123, FinishDate = DateTime.Now, IssueDate = DateTime.Now }));
                 jobViewModels = (IEnumerable<JobViewModel>)jobs;

             }*/
        private readonly IJobService jobService;
        public AllJobsViewModel(IJobService jobService,NavigationService<CreateMechanicViewModel> navigationStore)
        {          
            jobs = new ObservableCollection<JobViewModel>();
            navigaTeToManagers = new NavigateCommand<CreateMechanicViewModel>(navigationStore);
            this.jobService = jobService;
            jobViewModels = (IEnumerable<JobViewModel>)jobs;
         
            GetAllJobs();

        }

public  ObservableCollection<JobViewModel> jobs { get; set; }

        public async void GetAllJobs()
        {
            var models = await jobService.GetAllAsync();
           foreach(JobDTO model in models)
            {
                jobs.Add(new JobViewModel(model));


            }
        }
        

        public IEnumerable<JobViewModel> jobViewModels { get; set; } 
    }
}
