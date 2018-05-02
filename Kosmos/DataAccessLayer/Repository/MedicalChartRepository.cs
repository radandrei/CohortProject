using DataAccessLayer.Models;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class MedicalChartRepository : IMedicalChartRepository
    {
        private MedicalDBContext context;

        public MedicalChartRepository(MedicalDBContext context)
        {
            this.context = context;
        }

        public MedicalChart AddOrUpdate(MedicalChart entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<MedicalChart> GetAll()
        {
            var charts = this.context.MedicalCharts.ToList();

            return charts;
        }

        public MedicalChart GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
