using BusinessLayer.Interfaces;
using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.RepositoryInterfaces
{
    public interface IContraindicationRepository:IBaseRepository<Contraindication>
    {
        List<Contraindication> GetAllByMedicalChart(int medicalChartId);
    }
}
