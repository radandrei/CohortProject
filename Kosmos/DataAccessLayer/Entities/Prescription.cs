using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Prescription
    {
        public int Id { get; set; }
        public int MedicalChartID { get; set; }
        public int DiagnosisId { get; set; }

        public List<PrescribedMedicine> PrescribedMedicine;
        public MedicalChart MedicalChart;
        public Diagnosis Diagnosis;
    }
}
