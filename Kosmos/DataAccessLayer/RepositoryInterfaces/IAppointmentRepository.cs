using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IAppointmentRepository:IBaseRepository<Appointment>
    {
        List<Appointment> GetAllByPerson(int personId);
        List<Appointment> GetByPerson(int personId);
    }
}
