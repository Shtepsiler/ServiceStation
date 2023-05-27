using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStation.BLL.DTO.Requests
{
    public class NewJobRequest
    {
        public string ModelName { get; set; }
        public int ClientId { get; set; }
        public DateTime IssueDate { get; set; }
        public string Description { get; set; }
    }
}
