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

namespace WpfAppForManagers1._0.ViewModels.JobsViewModels
{
    public class JobControlViewModel : ViewModelBase
    {
        public ICommand navigateToHome { get; set; }
        public ICommand CreateJob { get; set; }
        public ICommand EditJob { get; set; }



        private readonly IJobService jobService;



        public JobControlViewModel(IJobService jobService, NavigationService<JobsForTodayViewModel> navigationStore,NavigationService<CreateJobViewModel> creare, NavigationService<EditJobViewModel> update)
        {
            jobs = new ObservableCollection<JobViewModel>();
            navigateToHome = new NavigateCommand<JobsForTodayViewModel>(navigationStore);
            CreateJob = new NavigateCommand<CreateJobViewModel>(creare);
            EditJob = new NavigateCommand<EditJobViewModel>(update);

            this.jobService = jobService;
            jobViewModels = jobs;

            GetAllJobs();

        }

        public ObservableCollection<JobViewModel> jobs { get; set; }

        public async void GetAllJobs()
        {
            var models = await jobService.GetAllAsync();
            foreach (JobDTO model in models)
            {
                jobs.Add(new JobViewModel(model));


            }
        }


        public IEnumerable<JobViewModel> jobViewModels { get; set; }

    }
}
