using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Contraindication
    {
        public int ID { get; set; }
        public int MedicineID { get; set; }
        public int MedicalChartID { get; set; }

        public MedicalChart MedicalChart { get; set; }
        public Medicine Medicine { get; set; }
    }
}
