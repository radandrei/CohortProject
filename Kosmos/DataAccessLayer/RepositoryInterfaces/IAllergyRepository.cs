using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IAllergyRepository : IBaseRepository<Allergy>
    {
        List<Allergy> GetAllByMedicalChart(int medicalChartId);
    }
}
