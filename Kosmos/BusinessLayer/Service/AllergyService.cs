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
    public class AllergyService
    {
        private IAllergyRepository allergyRepository;

        public AllergyService(MedicalDBContext context)
        {
            allergyRepository = new AllergyRepository(context);
        }

        public List<AllergyModel> getAllergiesByMedicalChart(int medicalChartId)
        {
            List < AllergyModel > allergyList= new List<AllergyModel>();
            List<Allergy> returnList = allergyRepository.GetAllByMedicalChart(medicalChartId);
            foreach (Allergy allergy in returnList)
                allergyList.Add(new AllergyModel(allergy));
            return allergyList;

        }
    }
}
