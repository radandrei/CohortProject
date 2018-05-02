using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class PrescriptionRepository : IPrescriptionRepository
    {
        MedicalDBContext context;
        public PrescriptionRepository(MedicalDBContext context)
        {
            this.context = context;
        }
        public Prescription AddOrUpdate(Prescription Prescription)
        {
            Prescription changedPrescription;

            try
            {
                if (Prescription.ID != 0)
                {
                    changedPrescription = context.Prescriptions.Where(x => x.ID == Prescription.ID).FirstOrDefault();
                    changedPrescription.PrescribedMedicine = new List<PrescribedMedicine>(Prescription.PrescribedMedicine);
                    context.Update(changedPrescription);
                }
                else
                {
                    changedPrescription = new Prescription()
                    {
                        PrescribedMedicine = new List<PrescribedMedicine>(Prescription.PrescribedMedicine)
                };
                    context.Add(changedPrescription);
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database insertion: " + ex);
            }

            context.SaveChanges();
            return changedPrescription;
        }

        public void Delete(int Id)
        {
            try
            {
                Prescription PrescriptionToDelete = new Prescription() { ID = Id };
                context.Entry(PrescriptionToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database deletion: " + ex);
            }
        }

        public List<Prescription> GetAll()
        {
            return context.Prescriptions.ToList();
        }

        public Prescription GetById(int Id)
        {
            var j = context.Prescriptions.Where(x => x.ID == Id).FirstOrDefault();
            return j;
        }

        public List<Prescription> GetAllByMedicalChart(int medicalChartId)
        {
            //IQueryable<Contraindication> DeterminedContraindications = context.Contraindications.Where(x => x.MedicalChartID == medicalChartId);
            //IQueryable<Medicine> DeterminedMedicine = context.Medicine.Where(x => DeterminedContraindications.Any(y => y.MedicineID == x.ID));
            //IQueryable<PrescribedMedicine> DeterminedPresribed = context.PrescribedMedicine.Where(x => DeterminedMedicine.Any(y => y.ID == x.MedicineID));
            //return context.Prescriptions.Where(x =>DeterminedPresribed.Any(y=>y.PrescriptionID==x.ID)).ToList();
            return context.Prescriptions.Where(x => x.MedicalChartID == medicalChartId).ToList();
        }
    }
}
