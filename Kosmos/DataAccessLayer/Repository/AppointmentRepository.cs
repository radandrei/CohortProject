using DataAccessLayer.Models;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class AppointmentRepository:IAppointmentRepository
    {
        MedicalDBContext context;
        public AppointmentRepository(MedicalDBContext context)
        {
            this.context = context;
        }
        public Appointment AddOrUpdate(Appointment Appointment)
        {
            Appointment changedAppointment;

            try
            {
                if (Appointment.ID != 0)
                {
                    changedAppointment = context.Appointments.Where(x => x.ID == Appointment.ID).FirstOrDefault();
                    changedAppointment.Date = Appointment.Date;
                    changedAppointment.Notes = Appointment.Notes;
                    changedAppointment.Confirmed = Appointment.Confirmed;
                    context.Update(changedAppointment);
                }
                else
                {
                    changedAppointment = new Appointment()
                    {
                        Date = Appointment.Date,
                        Notes = Appointment.Notes,
                        Confirmed = Appointment.Confirmed,
                        PersonID = Appointment.PersonID
                };
                    context.Add(changedAppointment);
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database insertion: " + ex);
            }

            context.SaveChanges();
            return changedAppointment;
        }

        public void Delete(int Id)
        {
            try
            {
                Appointment AppointmentToDelete = new Appointment() { ID = Id };
                context.Entry(AppointmentToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database deletion: " + ex);
            }
        }

        public List<Appointment> GetAll()
        {
            return context.Appointments.ToList();
        }

        public Appointment GetById(int Id)
        {
            var j = context.Appointments.Where(x => x.ID == Id).FirstOrDefault();
            return j;
        }

        public List<Appointment> GetAllByPerson(int personId)
        {
            return context.Appointments.Where(x => x.PersonID == personId && DateTime.Compare(x.Date,DateTime.Now)>0).ToList();
        }
    }
}

