using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Medicine
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<PrescribedMedicine> PrescribedMedicine{get;set;}
    }
}
