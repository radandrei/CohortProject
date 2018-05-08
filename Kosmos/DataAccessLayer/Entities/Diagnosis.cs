using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Diagnosis
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Event Event { get; set; }
        public Prescription Prescription { get; set; }
    }
}
