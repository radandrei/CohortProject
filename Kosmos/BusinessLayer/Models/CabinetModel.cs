using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BusinessLayer.Models
{
    public class CabinetModel
    {
        public int ID { get; set; }
        public string DoctorPosition { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        
        public CabinetModel(Cabinet cabinet)
        {
            if (cabinet != null)
            {
                ID = cabinet.ID;
                DoctorPosition = cabinet.DoctorPosition;
                Name = cabinet.Name;
                Address = cabinet.Address;
            }
        }
    }
}
