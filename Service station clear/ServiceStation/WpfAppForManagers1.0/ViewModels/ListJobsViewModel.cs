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






        public ListJobsViewModel()
        {
            jobs = new ObservableCollection<JobViewModel>();
            jobs.Add(new JobViewModel(new() { Id = 1, ClientId = 1, MechanicId = 1, ModelId = 1, ManagerId = 1, Status = "pending", Description = "blablabla", Price = 123, FinishDate = DateTime.Now, IssueDate = DateTime.Now }));
        }
    }
}
