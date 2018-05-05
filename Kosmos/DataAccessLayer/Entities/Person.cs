using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool Active { get; set; }
        public int MedicalChartID { get; set; }
        public int CabinetID { get; set; }
        public int UserId { get; set; }
        public int PersonalDataID { get; set; }


        public MedicalChart MedicalChart { get; set; }
        public Cabinet Cabinet { get; set; }
        public User User { get; set; }
        public PersonalData PersonalData { get; set; }

        public ICollection<Appointment> Appointments { get; set; }
    }
}
