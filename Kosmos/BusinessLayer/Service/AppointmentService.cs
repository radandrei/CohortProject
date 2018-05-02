using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessLayer.Service
{
    public class AppointmentService
    {
        private IAppointmentRepository AppointmentRepository;

        public AppointmentService(MedicalDBContext context)
        {
            AppointmentRepository = new AppointmentRepository(context);
        }

        public List<AppointmentModel> getAppointmentsByPerson(int personId)
        {
            List<AppointmentModel> AppointmentList = new List<AppointmentModel>();
            List<Appointment> returnList = AppointmentRepository.GetAllByPerson(personId);
            foreach (Appointment appointment in returnList)
                AppointmentList.Add(new AppointmentModel(appointment));
            return AppointmentList;

        }

        public AppointmentModel CreateAppointment(AppointmentModel appointment)
        {
            var saved = AppointmentRepository.AddOrUpdate(new Appointment()
            {
                ID=0,
                Date = appointment.Date,
                Notes = appointment.Notes,
                Confirmed = appointment.Confirmed,
                PersonID = 1
            });

            return new AppointmentModel(saved);
        }

        public void DeleteAppointment(int id)
        {
            AppointmentRepository.Delete(id);
        }
    }
}