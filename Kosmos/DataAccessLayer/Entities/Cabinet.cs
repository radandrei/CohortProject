using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Cabinet
    {
        public int ID { get; set; }
        public int MedicalDataID { get; set; }

        public ICollection<MedicalData> MedicalData { get; set; }

        public ICollection<Person> People { get; set; }
    }
}
