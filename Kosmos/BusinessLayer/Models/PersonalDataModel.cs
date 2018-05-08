using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class PersonalDataModel
    {
        public int ID { get; set; }
        public DateTime Birthdate { get; set; }

        public PersonalDataModel(PersonalData personalData)
        {
            ID = personalData.ID;
            Birthdate = personalData.Birthdate;
        }
    }
}
