using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Prescription
    {
        public int ID { get; set; }
        public int EventID { get; set; }

        public List<Medicine> Medicine { get; set; }
        public Event Event { get; set; }
    }
}
