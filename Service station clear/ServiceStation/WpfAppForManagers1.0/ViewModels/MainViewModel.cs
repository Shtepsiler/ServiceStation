using Application.DTOs.Respponces;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfAppForManagers1._0.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel;

        public MainViewModel()
        {
            jobs = new ObservableCollection<JobViewModel>();
            jobs.Add(new JobViewModel(new() { Id = 1, ClientId = 1, MechanicId = 1, ModelId = 1, ManagerId = 1, Status = "pending", Description = "blablabla", Price = 123, FinishDate = DateTime.Now, IssueDate = DateTime.Now }));
            jobViewModels =  (IEnumerable<JobViewModel>)jobs;
        }


        public  ObservableCollection<JobViewModel> jobs { get; }

        public IEnumerable<JobViewModel> jobViewModels { get; set; } 
    }
}
