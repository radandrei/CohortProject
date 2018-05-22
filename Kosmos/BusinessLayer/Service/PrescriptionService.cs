using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer.Service
{
    public class PrescriptionService
    {
        private IPrescriptionRepository PrescriptionRepository;

        public PrescriptionService(MedicalDBContext context)
        {
            PrescriptionRepository = new PrescriptionRepository(context);
        }

        public List<PrescriptionModel> GetAllergiesByMedicalChart(int medicalChartId)
        {
            //List<PrescriptionModel> PrescriptionList = new List<PrescriptionModel>();
            //List<Prescription> returnList = PrescriptionRepository.GetAllByMedicalChart(medicalChartId);
            //foreach (Prescription Prescription in returnList)
            //    PrescriptionList.Add(new PrescriptionModel(Prescription));
            //return PrescriptionList;

            return null;

        }

        public List<PrescriptionModel> GetPrescriptionsByMedicalChart(int medicalChartId)
        {
            var prescriptionList = PrescriptionRepository.GetAllByMedicalChart(medicalChartId);
            var returnList = prescriptionList.Select(x => new PrescriptionModel(x)).ToList();

            return returnList;
        }

        public object GetPrescriptionById(int id)
        {
            var prescription = PrescriptionRepository.GetById(id);
            return new PrescriptionPlusMedModel(prescription);
        }
    }
}
