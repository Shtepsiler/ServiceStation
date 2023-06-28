using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppForManagers1._0.Services;
using WpfAppForManagers1._0.ViewModels.JobsViewModels;
using WpfAppForManagers1._0.ViewModels;

namespace WpfAppForManagers1._0.Commands
{
    public class SubmitJobCommand : CommandBase
    {
        public CreateJobViewModel createJobViewModel { get; }

        private readonly IJobService JobsService;
        private NavigationService<JobsForTodayViewModel> navtohome;

        public SubmitJobCommand(CreateJobViewModel jobViewModel, IJobService jobsservice, NavigationService<JobsForTodayViewModel> navigationStore)
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


        public override void Execute(object? parameter)
        {
            try
            {

                 JobsService.Create(
                     new()
                     {
                         ClientId = createJobViewModel.ClientId,
                         Description = createJobViewModel.Description,
                         ModelId = createJobViewModel.ModelId,
                         IssueDate = createJobViewModel.IssueDate

                     }
                     );

   



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
