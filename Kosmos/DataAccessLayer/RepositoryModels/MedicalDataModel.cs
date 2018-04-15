using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class MedicalDataModel
    {
        public int ID { get; set; }
        public string Position { get; set; }

        public PersonModel Doctor { get; set; }
        public CabinetModel Cabinet { get; set; }

        public MedicalDataModel(MedicalData medicalData)
        {
            ID = medicalData.ID;
            Position = medicalData.Position;
            Doctor = new PersonModel(medicalData.Doctor);
            Cabinet = new CabinetModel(medicalData.Cabinet);
        }
    }
}
