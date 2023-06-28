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
using WpfAppForManagers1._0.Stores;

namespace WpfAppForManagers1._0.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private NavigationStore NavigationStore;


        public ViewModelBase CurrentViewModel => NavigationStore.CurrentViewModel;


        public MainViewModel()
        {
            jobs = new ObservableCollection<JobViewModel>();
            jobs.Add(new JobViewModel(new() { Id = 1, ClientId = 1, MechanicId = 1, ModelId = 1, ManagerId = 1, Status = "pending", Description = "blablabla", Price = 123, FinishDate = DateTime.Now, IssueDate = DateTime.Now }));
            jobViewModels = (IEnumerable<JobViewModel>)jobs;
        }
        private readonly IJobService jobService;
        public MainViewModel(IJobService jobService,NavigationStore navigationStore)
        {          
            jobs = new ObservableCollection<JobViewModel>();

            this.jobService = jobService;
            this.NavigationStore = navigationStore;
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
