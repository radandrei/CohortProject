﻿using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

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
            List<Appointment> returnList = AppointmentRepository.GetByPerson(personId);
            foreach (Appointment appointment in returnList)
                AppointmentList.Add(new AppointmentModel(appointment));
            return AppointmentList;

        }

        public List<AppointmentModel> getAllAppointmentsByPerson(int personId)
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
                Confirmed = true,
                PersonID = appointment.PersonId
            });

            return new AppointmentModel(saved);
        }

        public List<CabinetModel> GetCabinets()
        {
            List<Cabinet> cabinets = AppointmentRepository.GetCabinets();

            var returnList = cabinets.Select(x => new CabinetModel(x)).ToList();

            return returnList;
        }

        public void DeleteAppointment(int id)
        {
            AppointmentRepository.Delete(id);
        }
    }
}