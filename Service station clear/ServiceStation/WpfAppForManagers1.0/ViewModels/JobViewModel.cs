using Application.DTOs.Respponces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppForManagers1._0.ViewModels
{
    public class JobViewModel : ViewModelBase
    {
        private readonly JobDTO jobDTO;

        public JobViewModel(JobDTO jobDTO)
        {
            this.jobDTO = jobDTO;
        }

        public int Id => jobDTO.Id;
        public int? ManagerId => jobDTO.ManagerId;
        public int ModelId => jobDTO.ModelId;
        public string? Status => jobDTO.Status;
        public int ClientId => jobDTO.ClientId;
        public int? MechanicId => jobDTO.MechanicId;
        public DateTime IssueDate => jobDTO.IssueDate;
        public DateTime? FinishDate => jobDTO.FinishDate;
        public string Description => jobDTO.Description;
        public decimal? Price => jobDTO.Price;



    }
}
