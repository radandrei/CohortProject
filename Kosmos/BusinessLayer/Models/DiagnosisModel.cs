using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class DiagnosisModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

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
