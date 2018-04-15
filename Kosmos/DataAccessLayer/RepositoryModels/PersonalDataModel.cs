using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class PersonalDataModel
    {
        public int ID { get; set; }
        public DateTime Birthdate { get; set; }

        public PersonModel Person { get; set; }

        PersonalDataModel(PersonalData personalData)
        {
            ID = personalData.ID;
            Birthdate = personalData.Birthdate;
            Person = new PersonModel(personalData.Person);
        }
    }
}
