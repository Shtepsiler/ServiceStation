using Application.DTOs.Respponces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppForManagers1._0.Models
{
    public class MechanicViewModel
    {
        private MechanicDTO _mechanic;

        public MechanicViewModel(MechanicDTO mechanic)
        {
            _mechanic = mechanic;
        }
        public int Id => _mechanic.Id;
        public string FirstName => _mechanic.FirstName;
        public string LastName => _mechanic.LastName;
        public string Address => _mechanic.Address;
        public string Phone => _mechanic.Phone;
        public string Password => _mechanic.Password;
        public string Specialization => _mechanic.Specialization;
    }
}
