using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using BusinessLayer.Models;
using DataAccessLayer.Models;

namespace BusinessLayer.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }

        public MedicalChartModel MedicalChart { get; set; }
        public CabinetModel Cabinet { get; set; }
        public PersonalDataModel PersonalData { get; set; }

        //public ICollection<MedicalDataModel> MedicalData { get; set; }
        //public ICollection<AppointmentModel> Appointments { get; set; }

        public PersonModel(Person person)
        {
            ID = person.ID;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Active = person.Active;
            MedicalChart=new MedicalChartModel(person.MedicalChart);
            Cabinet = new CabinetModel(person.Cabinet);
            PersonalData = new PersonalDataModel(person.PersonalData);

        }
    }
}
