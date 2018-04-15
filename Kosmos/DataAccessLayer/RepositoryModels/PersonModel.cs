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
        public UserModel User { get; set; }
        public PersonalDataModel PersonalData { get; set; }

        public ICollection<MedicalDataModel> MedicalData { get; set; }
        public ICollection<AppointmentModel> Appointments { get; set; }

        public PersonModel(Person person)
        {
            ID = person.ID;
            FirstName = person.FirstName;
            LastName = person.LastName;
            Active = person.Active;

            MedicalData = new Collection<MedicalDataModel>();
            Appointments = new Collection<AppointmentModel>();

            foreach (MedicalData MD in person.MedicalData)
                MedicalData.Add(new MedicalDataModel(MD));

            foreach (Appointment A in person.Appointments)
                Appointments.Add(new AppointmentModel(A));
        }
    }
}
