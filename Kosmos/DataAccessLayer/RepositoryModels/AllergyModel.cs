using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AllergyModel
    {
        public int ID { get; set; }

        //public MedicalChartModel MedicalChart { get;set; }
        public AllergicReactionModel AllergicReaction { get; set; }

        public AllergyModel(Allergy allergy)
        {
            ID = allergy.ID;
            //MedicalChart = new MedicalChartModel(allergy.MedicalChart);
            AllergicReaction = new AllergicReactionModel(allergy.AllergicReaction);
        }
    }
}
