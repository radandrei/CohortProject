using BusinessLayer.Models;
using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryModels
{
    public class PrescribedMedicineModel
    {
        public int ID { get; set; }
        public MedicineModel Medicine { get; set; }
        public PrescriptionModel Prescription { get; set; }
        public PrescribedMedicineModel(PrescribedMedicine prescribedMedicine) {
            ID = prescribedMedicine.ID;
            Medicine = new MedicineModel(prescribedMedicine.Medicine);
            Prescription = new PrescriptionModel(prescribedMedicine.Prescription);
        }
    }
}
