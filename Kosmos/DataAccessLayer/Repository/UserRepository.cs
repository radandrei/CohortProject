using BusinessLayer.Interfaces;
using DataAccessLayer;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    public class UserRepository : IUserRepository
    {
        private MedicalDBContext context;

        public UserRepository(MedicalDBContext context)
        {
            this.context = context;
        }

        public User AddOrUpdate(User entity)
        {
            throw new NotImplementedException();
        }

        public User CreateUser(User user)
        {
            var newUser = new User();
            newUser = context.Users.Where(x => x.Username.ToLower().Equals(user.Username.ToLower())).Include(u=>u.Person).Include(r=>r.Role).AsNoTracking().FirstOrDefault();

            try
            {
                if (newUser == null)
                {
                    newUser = new User()
                    {
                        Username = user.Username,
                        Password = user.Password,
                        RoleId = user.RoleId
                    };
                    context.Add(newUser);
                }
                else
                {
                    throw new InvalidOperationException("User already exists");
                }
            }
            catch (DbUpdateException ex)
            {
                throw ex;
            }
            context.SaveChanges();

            return GetById(newUser.Id);
        }

        public void Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<User> GetAll()
        {
            return context.Users.Include(z => z.Role).Include(z=>z.Person).Include(z=>z.Person.Cabinet).AsNoTracking().ToList();
        }

        public User GetById(int id)
        {
            return context.Users.Where(x => x.Id == id).Include(z => z.Role).Include(y => y.Person).Include(a => a.Person.PersonalData)
                .Include(b => b.Person.MedicalChart).Include(c => c.Person.Cabinet)
                .AsNoTracking().FirstOrDefault();
        }

        public User GetByUsername(string username)
        {
            return context.Users.Where(x => x.Username.Equals(username)).Include(z => z.Role).AsNoTracking().FirstOrDefault();
        }
    }
}
