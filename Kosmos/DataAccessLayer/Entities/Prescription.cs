using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class Prescription
    {
        public int ID { get; set; }
        //public int EventID { get; set; }
        //public Event Event { get; set; }
        public int MedicalChartID { get; set; }
        public List<PrescribedMedicine> PrescribedMedicine;
        public MedicalChart MedicalChart;
        public Diagnosis Diagnosis;
    }
}
