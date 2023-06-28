using Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfAppForManagers1._0.Commands;
using WpfAppForManagers1._0.Services;

namespace WpfAppForManagers1._0.ViewModels.JobsViewModels
{
    public class CreateJobViewModel : ViewModelBase
    {


        public CreateJobViewModel(NavigationService<JobsForTodayViewModel> navigationStore, IJobService jobService)
        {
            SubmitCommand = new SubmitJobCommand(this, jobService, navigationStore);
            CancelCommand = new NavigateCommand<JobsForTodayViewModel>(navigationStore);
            GoHomeCommand = new NavigateCommand<JobsForTodayViewModel>(navigationStore);

        }
        public ICommand GoHomeCommand { get; }
        public ICommand SubmitCommand { get; }
        public ICommand CancelCommand { get; }

        private int? managerId;
        public int? ManagerId
        {
            get { return managerId; }
            set
            {
                managerId = value;
                OnPropertyChanged(nameof(ManagerId));
            }
        }

        private int modelId;
        public int ModelId
        {
            get { return modelId; }
            set
            {
                modelId = value;
                OnPropertyChanged(nameof(ModelId));
            }
        }

        private string? status;
        public string? Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private int clientId;
        public int ClientId
        {
            get { return clientId; }
            set
            {
                clientId = value;
                OnPropertyChanged(nameof(ClientId));
            }
        }

        private int? mechanicId;
        public int? MechanicId
        {
            get { return mechanicId; }
            set
            {
                mechanicId = value;
                OnPropertyChanged(nameof(MechanicId));
            }
        }

        private DateTime issueDate;
        public DateTime IssueDate
        {
            get { return issueDate; }
            set
            {
                issueDate = value;
                OnPropertyChanged(nameof(IssueDate));
            }
        }

        private DateTime? finishDate;
        public DateTime? FinishDate
        {
            get { return finishDate; }
            set
            {
                finishDate = value;
                OnPropertyChanged(nameof(FinishDate));
            }
        }

        private string description;
        public string Description
        {
            get { return description; }
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        private decimal? price;
        public decimal? Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged(nameof(price));
            }
        }
















    }
}
