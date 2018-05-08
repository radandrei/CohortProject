using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Prescription
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public int MedicalChartID { get; set; }
        public int DiagnosisID { get; set; }

        public MedicalChart MedicalChart { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public ICollection<PrescribedMedicine> PrescribedMedicine { get; set; }

    }
}
