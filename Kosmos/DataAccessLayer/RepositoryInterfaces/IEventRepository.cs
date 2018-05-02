using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IEventRepository:IBaseRepository<Event>
    {
        List<Event> GetAllByMedicalChart(int medicalChartId);
    }
}
