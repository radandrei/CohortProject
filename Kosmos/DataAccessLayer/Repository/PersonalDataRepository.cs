using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class PersonalDataRepository : IPersonalDataRepository
    {
        private readonly MedicalDBContext context;

        public PersonalDataRepository(MedicalDBContext context)
        {
            this.context = context;
        }

        public PersonalData AddOrUpdate(PersonalData entity)
        {
            var personalData = context.PersonalData.FirstOrDefault(p => p.ID == entity.ID);

            if (personalData == null)
            {
                personalData = new PersonalData()
                {
                    Birthdate = entity.Birthdate
                };
                context.PersonalData.Add(personalData);
            }
            else
            {
                personalData.Birthdate = entity.Birthdate;
                context.PersonalData.Update(personalData);
            }
            context.SaveChanges();

            return personalData;
        }


        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<PersonalData> GetAll()
        {
            throw new NotImplementedException();
        }

        public PersonalData GetById(int Id)
        {
            throw new NotImplementedException();
        }
    }
}
