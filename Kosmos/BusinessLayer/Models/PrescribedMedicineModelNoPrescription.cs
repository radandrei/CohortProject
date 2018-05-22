using BusinessLayer.Models;
using DataAccessLayer.Entities;

namespace DataAccessLayer.RepositoryModels
{
    public class PrescribedMedicineModelNoPrescription
    {
        public int ID { get; set; }
        public MedicineModel Medicine { get; set; }
        public PrescribedMedicineModelNoPrescription(PrescribedMedicine prescribedMedicine)
        {
            ID = prescribedMedicine.ID;
            Medicine = new MedicineModel(prescribedMedicine.Medicine);
        }
    }
}
