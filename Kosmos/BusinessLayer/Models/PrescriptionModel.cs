using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class PrescriptionModel
    {
        public int Id { get; set; }
        public int DiagnosisId { get; set; }

        public PrescriptionModel(Prescription prescription)
        {
            Id = prescription.Id;
            DiagnosisId = prescription.DiagnosisId;
        }
    }
}
