using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AppointmentModel
    {
        public int ID { get; set; }
        public DateTime Date { get; set; }
        public bool Confirmed { get; set; }
        public string Notes { get; set; }
        public int PersonId { get; set; }

        //public PersonModel Person { get; set; }

        public AppointmentModel() { }

        public AppointmentModel(DateTime Date, string notes, bool Confirmed)
        {
            this.Date = Date;
            this.Confirmed = Confirmed;
            this.Notes = Notes;
        }


        public AppointmentModel(AppointmentModel appointment)
        {
            Date = appointment.Date;
            Confirmed = appointment.Confirmed;
            Notes = appointment.Notes;
        }

        public AppointmentModel(Appointment appointment)
        {
            ID = appointment.ID;
            Date = appointment.Date;
            Confirmed = appointment.Confirmed;
            Notes = appointment.Notes;
            //Person = new PersonModel(appointment.Person);
        }
    }
}
