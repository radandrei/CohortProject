using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class MedicineModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public MedicineModel(Medicine medicine)
        {
            ID = medicine.ID;
            Name = medicine.Name;
        }
    }
}
