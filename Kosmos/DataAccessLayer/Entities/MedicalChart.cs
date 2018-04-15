﻿using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class MedicalChart
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }

        public ICollection<Event> Events{ get; set; }
        public ICollection<Contraindication> Contraindications { get; set; }
        public ICollection<Allergy> Allergies { get; set; }
        public ICollection<MedicalChartHistory> ChartModifications { get; set; }
    }
}