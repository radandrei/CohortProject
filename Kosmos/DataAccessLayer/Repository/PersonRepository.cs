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
            throw new NotImplementedException();
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
