using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;


namespace BusinessLayer.Service
{
    public class AppointmentService
    {
        private IAppointmentRepository AppointmentRepository;
        private IPersonRepository PersonRepository;

        public AppointmentService(MedicalDBContext context)
        {
            AppointmentRepository = new AppointmentRepository(context);
            PersonRepository = new PersonRepository(context);
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
            var person = PersonRepository.GetById(appointment.PersonId);
            if (person == null)
                throw new ArgumentException("Person not found");

            var saved = AppointmentRepository.AddOrUpdate(new Appointment()
            {
                ID=appointment.ID,
                Date = appointment.Date,
                Notes = appointment.Notes,
                Confirmed = appointment.Confirmed,
                PersonID = appointment.PersonId
            });

            return new AppointmentModel(saved);
        }

        public void DeleteAppointment(int id)
        {
            AppointmentRepository.Delete(id);
        }
    }
}