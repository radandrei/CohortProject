using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class MedicalChartHistory
    {
        public int ID { get; set; }
        public DateTime DateModified { get; set; }
        public int MedicalChartID { get; set; }

        public MedicalChart MedicalChart { get; set; }
    }
}
