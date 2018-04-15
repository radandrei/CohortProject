using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class PrescriptionModel
    {
        public int ID { get; set; }

        public List<MedicineModel> Medicine { get; set; }
        public EventModel Event { get; set; }

        public PrescriptionModel(Prescription prescription)
        {
            ID = prescription.ID;
            Medicine = new List<MedicineModel>();
            foreach (Medicine M in prescription.Medicine)
                Medicine.Add(new MedicineModel(M));
            
            Event = new EventModel(prescription.Event);
        }
    }
}
