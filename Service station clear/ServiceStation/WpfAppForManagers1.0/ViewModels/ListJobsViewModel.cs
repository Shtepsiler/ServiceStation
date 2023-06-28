using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppForManagers1._0.ViewModels
{
    public class ListJobsViewModel : ViewModelBase
    {
        public ICommand RedirectToMechanicControl { get; }
        public ICommand RedirectToJobControl { get; }
        public ICommand RedirectToClientControl { get; }
        public ICommand RedirectToPartsControl { get; }

        public ObservableCollection<JobViewModel> jobs { get; set; }

        private readonly IJobService jobService;




        public  ListJobsViewModel(IJobService jobService )
        {
        this.jobService = jobService;

            GetAllJobs();

        }



        public async void GetAllJobs()
        {
            jobs = (ObservableCollection<JobViewModel>)await jobService.GetAllAsync();
        }
    }
}
