using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.Models
{
    public class CabinetModel
    {
        public int ID { get; set; }

        public ICollection<MedicalDataModel> MedicalData { get; set; }

        public ICollection<PersonModel> People { get; set; }

        public CabinetModel(Cabinet cabinet)
        {
            ID = cabinet.ID;
            MedicalData = new Collection<MedicalDataModel>();
            foreach(MedicalData MD in cabinet.MedicalData)
            {
                MedicalData.Add(new MedicalDataModel(MD));
            }

        }
    }
}
