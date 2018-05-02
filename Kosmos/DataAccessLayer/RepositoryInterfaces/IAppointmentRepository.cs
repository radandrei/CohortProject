using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IAppointmentRepository:IBaseRepository<Appointment>
    {
        List<Appointment> GetAllByPerson(int personId);
    }
}
