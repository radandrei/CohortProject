using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryModels;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Models
{
    public class PrescriptionPlusMedModel
    {
        public int Id { get; set; }
        public DiagnosisModel Diagnosis { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; }
        public List<PrescribedMedicineModelNoPrescription> PrescribedMedicine=new List<PrescribedMedicineModelNoPrescription>();


        public PrescriptionPlusMedModel(Prescription prescription)
        {
            Id = prescription.ID;
            if (prescription.Diagnosis != null)
                Diagnosis = new DiagnosisModel(prescription.Diagnosis);
            Date = prescription.Date;
            Notes = prescription.Notes;
            foreach(PrescribedMedicine PMM in prescription.PrescribedMedicine)
            {
                PrescribedMedicine.Add(new PrescribedMedicineModelNoPrescription(PMM));
            }
        }
    }
}
