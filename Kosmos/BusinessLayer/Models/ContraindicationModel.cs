using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class ContraindicationModel
    {
        public int ID { get; set; }

        //public MedicalChartModel MedicalChart { get; set; }
        public MedicineModel Medicine { get; set; }

        public ContraindicationModel(Contraindication contraindication) {
            //MedicalChart = new MedicalChartModel(contraindication.MedicalChart);
            Medicine = new MedicineModel(contraindication.Medicine);
        }
    }
}
