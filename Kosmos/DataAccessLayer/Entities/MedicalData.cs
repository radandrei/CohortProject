using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class MedicalData
    {
        public int ID { get; set; }
        public string Position { get; set; }
        public int DoctorID { get; set; }
        public int CabinetID { get; set; }

        public Person Doctor { get; set; }
        public Cabinet Cabinet { get; set; }
    }
}
