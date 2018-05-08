using DataAccessLayer.Entities;
using System;

namespace BusinessLayer.Models
{
    public class PrescriptionModel
    {
        public int Id { get; set; }
        public DiagnosisModel Diagnosis { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }


        public PrescriptionModel(Prescription prescription)
        {
            Id = prescription.ID;
            if (prescription.Diagnosis != null)
                Diagnosis = new DiagnosisModel(prescription.Diagnosis);
            Date = prescription.Date;
            Notes = prescription.Notes;
        }
    }
}
