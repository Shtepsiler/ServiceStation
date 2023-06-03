using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class OrderPart
    {
        public int Id { get; set; } 
        public int OrderId { get; set; }
       
        public int PartId { get; set; }
       
        public int Quantity { get; set; }
    }
}
