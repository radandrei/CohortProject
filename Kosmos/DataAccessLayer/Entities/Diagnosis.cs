using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Diagnosis
    {
        public int ID { get; set; }
        public int PrescriptionID { get; set; }

        public Event Event { get; set; }
        public Prescription Prescription { get; set; }
    }
}
