using Application.DTOs.Respponces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppForManagers1._0.Models
{
    public class ClientViewModel
    {
        private readonly ClientDTO clientDTO;

        public ClientViewModel(ClientDTO clientDTO)
        {
            this.clientDTO = clientDTO;
        }


        public int Id => clientDTO.Id;
        public string UserName => clientDTO.UserName;
        public string FirstName => clientDTO.FirstName;
        public string LastName => clientDTO.LastName;
        public string PhoneNumber => clientDTO.PhoneNumber;
        public string Email => clientDTO.Email;

    }
}
