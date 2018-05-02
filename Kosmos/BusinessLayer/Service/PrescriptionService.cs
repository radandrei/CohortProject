using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessLayer.Service
{
    public class PrescriptionService
    {
        private IPrescriptionRepository PrescriptionRepository;

        public PrescriptionService(MedicalDBContext context)
        {
            PrescriptionRepository = new PrescriptionRepository(context);
        }

        public List<PrescriptionModel> getAllergiesByMedicalChart(int medicalChartId)
        {
            List<PrescriptionModel> PrescriptionList = new List<PrescriptionModel>();
            List<Prescription> returnList = PrescriptionRepository.GetAllByMedicalChart(medicalChartId);
            foreach (Prescription Prescription in returnList)
                PrescriptionList.Add(new PrescriptionModel(Prescription));
            return PrescriptionList;

        }
    }
}
