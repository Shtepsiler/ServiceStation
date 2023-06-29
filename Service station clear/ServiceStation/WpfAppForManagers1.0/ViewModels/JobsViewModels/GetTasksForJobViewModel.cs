using Application.DTOs.Respponces;
using Application.Interfaces;
using Application.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using WpfAppForManagers1._0.Commands;
using WpfAppForManagers1._0.Models;
using WpfAppForManagers1._0.Services;

namespace WpfAppForManagers1._0.ViewModels.JobsViewModels
{
    public class GetTasksForJobViewModel : ViewModelBase
    {
       private readonly IMechanicsTasksService MechanicsTasks;
    public GetTasksForJobViewModel( IMechanicsTasksService mechanicsTasks, NavigationService<JobsForTodayViewModel> navigationStore)
        {
            MechanicsTasks = mechanicsTasks;
            GoHomeCommand = new NavigateCommand<JobsForTodayViewModel>(navigationStore);
            tasxs = new ObservableCollection<MechanicsTasksViewModel>();
            FindCommand = new Find(this);




            mechanicsTasksViewModel = tasxs;
            GetTasks();
        }

        public ICommand GoHomeCommand { get; }
        public ICommand FindCommand { get;}


        private class Find : CommandBase
        {
            GetTasksForJobViewModel jobViewModel;

            public Find(GetTasksForJobViewModel jobViewModel)
            {
                this.jobViewModel = jobViewModel;
            }

            public override void Execute(object? parameter)
            {
                jobViewModel.GetTasksByParametrs(jobViewModel.JobId, jobViewModel.MechanicId);
            }
        }




        private int mechanicId;
        public int MechanicId
        {
            get { return mechanicId; }
            set
            {
                mechanicId = value;
                OnPropertyChanged(nameof(MechanicId));
            }
        }

        private int jobId;
        public int JobId
        {
            get { return jobId; }
            set
            {
                jobId = value;
                OnPropertyChanged(nameof(JobId));
            }
        }


 
        public ObservableCollection<MechanicsTasksViewModel> tasxs { get; set; }

        public async void GetTasks()
        {
            var models = await MechanicsTasks.GetAllAsync();
            foreach (var model in models)
            {
                tasxs.Add(new MechanicsTasksViewModel(model));


            }
        }
        public async void GetTasksByParametrs(int jobid, int Mechanicid )
        {
            var models = await MechanicsTasks.GetAllByParametrs(jobid, Mechanicid);
            tasxs.Clear();
            foreach (var model in models)
            {
                tasxs.Add(new MechanicsTasksViewModel(model));


            }
        }

        public IEnumerable<MechanicsTasksViewModel> mechanicsTasksViewModel { get; set; }







    }
}
