using DataAccessLayer.Entities;
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
            var medicalChart = context.MedicalCharts.FirstOrDefault(x => x.ID == entity.ID);

            if (medicalChart == null)
            {
                medicalChart = new MedicalChart()
                {
                    Notes = entity.Notes,
                    CreationDate = entity.CreationDate
                };
                context.MedicalCharts.Add(medicalChart);
            }
            else
            {
                medicalChart.CreationDate = entity.CreationDate;
                medicalChart.Notes = entity.Notes;
                context.MedicalCharts.Update(medicalChart);
            }

            context.SaveChanges();
            return medicalChart;
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
