using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.ViewModels.MechanicsViewsModels;
using WpfAppForManagers1._0.ViewModels;
using WpfAppForManagers1._0.ViewModels.JobsViewModels;
using Domain.Entities;
using System.Diagnostics;

namespace WpfAppForManagers1._0.Commands
{
    public class UpdateJobCommand : CommandBase
    {
        public EditJobViewModel createJobViewModel { get; }

        private readonly IJobService JobsService;
        private NavigationService<JobsForTodayViewModel> navtohome;

        public UpdateJobCommand(EditJobViewModel jobViewModel, IJobService jobsservice, NavigationService<JobsForTodayViewModel> navigationStore)
        {
            createJobViewModel = jobViewModel;
            JobsService = jobsservice;
            createJobViewModel.PropertyChanged += OnViewModelPropertyChanged;
            navtohome = navigationStore;
        }


        public void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            if (args.PropertyName == nameof(createJobViewModel.ClientId))
            {
                OnCanExecuteChanged();
            }

        }


        public override async void Execute(object? parameter)
        {
            try
            {

                var job = await JobsService.GetByIdAsync(createJobViewModel.Id);

                if (job == null) throw new Exception() ;
                
                     


                   await  JobsService.Update(new(){
                        Id = job.Id,
                        ManagerId = createJobViewModel.ManagerId,
                    ModelId = createJobViewModel.ModelId,
                    Status = createJobViewModel.Status,
                    ClientId = createJobViewModel.ClientId,
                    MechanicId = createJobViewModel.MechanicId,
                    IssueDate = createJobViewModel.IssueDate,
                    FinishDate = createJobViewModel.FinishDate,
                    Description = createJobViewModel.Description,
                    Price = createJobViewModel.Price
                    });

             



            }
            catch (Exception ex)
            {
                throw ex;

            }
            finally
            {
                navtohome.Navigate();
            }
        }
    }
}
