using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Text;


namespace BusinessLayer.Service
{
    public class ContraindicationService
    {
        private IContraindicationRepository ContraindicationRepository;

        public ContraindicationService(MedicalDBContext context)
        {
            ContraindicationRepository = new ContraindicationRepository(context);
        }

        public List<ContraindicationModel> getAllergiesByMedicalChart(int medicalChartId)
        {
            List<ContraindicationModel> ContraindicationList = new List<ContraindicationModel>();
            List<Contraindication> returnList = ContraindicationRepository.GetAllByMedicalChart(medicalChartId);
            foreach (Contraindication Contraindication in returnList)
                ContraindicationList.Add(new ContraindicationModel(Contraindication));
            return ContraindicationList;

        }
    }
}