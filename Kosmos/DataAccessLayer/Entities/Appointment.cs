using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Appointment
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public int PersonID { get; set; }
        public bool Confirmed { get; set; }
        public string Notes { get; set; }

        public Person Person { get; set; }
    }
}
