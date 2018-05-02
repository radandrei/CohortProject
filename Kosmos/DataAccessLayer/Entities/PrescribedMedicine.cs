using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
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
