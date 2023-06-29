using Application.DTOs.Respponces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppForManagers1._0.Models
{
    public  class MechanicsTasksViewModel
    {
        private MechanicsTasksDTO _tasks;

        public MechanicsTasksViewModel(MechanicsTasksDTO tasks)
        {
            _tasks = tasks;
        }
        public int Id => _tasks.Id;
        public int MechanicId => _tasks.MechanicId;

        public int? JobId => _tasks.JobId;

        public string Task => _tasks.Task;
        public string? Status => _tasks.Status;
    }
}
