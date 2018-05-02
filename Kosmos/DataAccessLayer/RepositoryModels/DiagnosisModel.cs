using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class DiagnosisModel
    {
        public int ID { get; set; }
        //public EventModel Event { get; set; }
        public PrescriptionModel Prescription { get; set; }

        public DiagnosisModel(Diagnosis diagnosis)
        {
            ID = diagnosis.ID;
            //Event = new EventModel(diagnosis.Event);
            Prescription = new PrescriptionModel(diagnosis.Prescription);
        }
    }
}
