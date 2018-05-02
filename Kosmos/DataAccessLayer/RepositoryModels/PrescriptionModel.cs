using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoryModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class PrescriptionModel
    {
        public int ID { get; set; }


        //public EventModel Event { get; set; }
        //public List<PrescribedMedicineModel> PrescribedMedicine;
        //public DiagnosisModel Diagnosis;

        public PrescriptionModel(Prescription prescription)
        {
            ID = prescription.ID;
            //if(prescription.Diagnosis!=null)
            //    Diagnosis = new DiagnosisModel(prescription.Diagnosis);
            //this.PrescribedMedicine = new List<PrescribedMedicineModel>();
            //foreach(PrescribedMedicine prescribedMedicine in prescription.PrescribedMedicine)
            //{
            //    PrescribedMedicine.Add(new PrescribedMedicineModel(prescribedMedicine));
            //}
        }
    }
}
