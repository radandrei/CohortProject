using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using DataAccessLayer.Utils;
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
            changedAppointment = context.Appointments.FirstOrDefault(x => x.ID == Appointment.ID);

            try
            {
                if (changedAppointment != null)
                {
                    changedAppointment.Date = Appointment.Date;
                    changedAppointment.Notes = Appointment.Notes;
                    changedAppointment.Confirmed = Appointment.Confirmed;
                    changedAppointment.PersonID = Appointment.PersonID;
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

        public List<Appointment> GetByPerson(int personId)
        {
            return context.Appointments.Where(x => x.PersonID == personId && DateTime.Compare(x.Date,DateTime.Now)>0).ToList();
        }

        public List<Cabinet> GetCabinets()
        {
            return context.Cabinets.ToList();
        }
        
        public List<Appointment> GetAllByPerson(int personId)
        {
            var user = context.Users.Include(a=>a.Role).Include(a=>a.Person).Single(a => a.Id == personId);
            var isMedic = user.Role.Id == (int)RoleEnum.Medic;
            if (isMedic)
            {
                var appointments = context.Persons.Where(a => a.CabinetID == user.Person.CabinetID && a.User.Role.Id == (int)RoleEnum.Patient).SelectMany(a => a.Appointments);
                var now = DateTime.Now.Date;
                return appointments.Where(a=>a.Date.Date >= now).OrderBy(a=>a.Date).ToList();
            }
            return context.Appointments.Where(x => x.PersonID == personId).ToList();
        }
    }
}

