using BusinessLayer.Interfaces;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IPrescriptionRepository:IBaseRepository<Prescription>
    {
        List<Prescription> GetAllByMedicalChart(int medicalChartId);
    }
}
