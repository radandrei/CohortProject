using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class DiagnosisModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DiagnosisModel(Diagnosis diagnosis)
        {
            Id = diagnosis.ID;
            Name = diagnosis.Name;
        }
    }
}
