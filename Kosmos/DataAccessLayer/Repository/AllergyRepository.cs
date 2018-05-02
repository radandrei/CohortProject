using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class AllergyRepository : IAllergyRepository
    {
        MedicalDBContext context;
        public AllergyRepository(MedicalDBContext context)
        {
            this.context = context;
        }
        public Allergy AddOrUpdate(Allergy allergy)
        {
            Allergy changedAllergy;

            try
            {
                if (allergy.ID != 0)
                {
                    changedAllergy = context.Allergies.Where(x => x.ID == allergy.ID).FirstOrDefault();
                    changedAllergy.AllergicReaction = allergy.AllergicReaction;
                    context.Update(changedAllergy);
                }
                else
                {
                    changedAllergy = new Allergy()
                    {
                        AllergicReaction = allergy.AllergicReaction
                    };
                    context.Add(changedAllergy);
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database insertion: " + ex);
            }

            context.SaveChanges();
            return changedAllergy;
        }

        public void Delete(int Id)
        {
            try
            {
                Allergy allergyToDelete = new Allergy() { ID = Id };
                context.Entry(allergyToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database deletion: " + ex);
            }
        }

        public List<Allergy> GetAll()
        {
            return context.Allergies.ToList();
        }

        public Allergy GetById(int Id)
        {
            var j = context.Allergies.Where(x => x.ID == Id).FirstOrDefault();
            return j;
        }

        public List<Allergy> GetAllByMedicalChart(int medicalChartId)
        {
            return context.Allergies.Where(x => x.MedicalChartID == medicalChartId).Include(x=>x.AllergicReaction).AsNoTracking().ToList();
        }
    }
}
