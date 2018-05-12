using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class PersonRepository : IPersonRepository
    {
        MedicalDBContext context;

        public PersonRepository(MedicalDBContext context)
        {
            this.context = context;
        }

        public Person AddOrUpdate(Person entity)
        {
            var person = context.Persons.FirstOrDefault(x => x.Id == entity.Id);

            if (person == null)
            {
                person = new Person(entity);
                context.Add(person);
            }

            else
            {
                person.FirstName = entity.FirstName;
                person.LastName = entity.LastName;
                person.CabinetID = entity.CabinetID;
                person.MedicalChartID = entity.MedicalChartID;
                person.PersonalDataID = entity.PersonalDataID;
                person.Active = entity.Active;
                person.UserId = entity.UserId;
                context.Persons.Update(person);
            }

            context.SaveChanges();

            return person;
        }

        public void Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public List<Person> GetAll()
        {
            throw new NotImplementedException();
        }

        public Person GetById(int Id)
        {
            try
            {
                return context.Persons.FirstOrDefault(x => x.Id == Id);
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
        }
    }
}
