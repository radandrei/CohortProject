using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class MedicalChartHistoryModel
    {
        public int ID { get; set; }
        public DateTime DateModified { get; set; }
        public MedicalChartModel MedicalChart { get; set; }

        public MedicalChartHistoryModel(MedicalChartHistory medicalChartHistory)
        {
            ID = medicalChartHistory.ID;
            DateModified = medicalChartHistory.DateModified;
            MedicalChart = new MedicalChartModel(medicalChartHistory.MedicalChart);
        }
    }
}
