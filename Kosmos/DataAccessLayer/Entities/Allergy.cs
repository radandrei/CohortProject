using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Allergy
    {
        public int ID { get; set; }
        public int MedicalChartID { get; set; }
        public int AllergicReactionID { get; set; }

        public MedicalChart MedicalChart { get; set; }
        public AllergicReaction AllergicReaction { get; set; }
    }
}
