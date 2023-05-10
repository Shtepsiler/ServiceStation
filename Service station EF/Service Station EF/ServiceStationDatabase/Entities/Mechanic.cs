﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceStationDatabase.Entities
{
    public class Mechanic
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Specialization { get; set; }
        [NotMapped]
        public List<Job> Jobs { get; set; }
        [NotMapped]
        public List<MechanicsTasks> Tasks { get; set; }
    }
}
