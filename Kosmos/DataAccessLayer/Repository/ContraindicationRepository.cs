using System;
using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class ContraindicationRepository : IContraindicationRepository
    {
        MedicalDBContext context;
        public ContraindicationRepository(MedicalDBContext context)
        {
            this.context = context;
        }
        public Contraindication AddOrUpdate(Contraindication Contraindication)
        {
            Contraindication changedContraindication;

            try
            {
                if (Contraindication.ID != 0)
                {
                    changedContraindication = context.Contraindications.Where(x => x.ID == Contraindication.ID).FirstOrDefault();
                    changedContraindication.Medicine = Contraindication.Medicine;
                    context.Update(changedContraindication);
                }
                else
                {
                    changedContraindication = new Contraindication()
                    {
                        Medicine = Contraindication.Medicine
                    };
                    context.Add(changedContraindication);
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database insertion: " + ex);
            }

            context.SaveChanges();
            return changedContraindication;
        }

        public void Delete(int Id)
        {
            try
            {
                Contraindication ContraindicationToDelete = new Contraindication() { ID = Id };
                context.Entry(ContraindicationToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database deletion: " + ex);
            }
        }

        public List<Contraindication> GetAll()
        {
            return context.Contraindications.ToList();
        }

        public Contraindication GetById(int Id)
        {
            var j = context.Contraindications.Where(x => x.ID == Id).FirstOrDefault();
            return j;
        }

        public List<Contraindication> GetAllByMedicalChart(int medicalChartId)
        {
            return context.Contraindications.Where(x => x.MedicalChartID == medicalChartId).Include(x => x.Medicine).AsNoTracking().ToList();
        }
    }
}
