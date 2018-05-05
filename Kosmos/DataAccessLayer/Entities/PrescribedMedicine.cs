namespace DataAccessLayer.Entities
{
    public class PrescribedMedicine
    {
        public int ID{ get; set; }
        public int MedicineID { get; set; }
        public int PrescriptionID { get; set; }
        public Medicine Medicine{ get; set; }
        public Prescription Prescription{get;set;}
    }
}
