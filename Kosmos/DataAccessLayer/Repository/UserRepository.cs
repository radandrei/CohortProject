using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
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

        public UserModel AddOrUpdate(UserModel entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public List<UserModel> GetAll()
        {
            return context.Users.Include(z => z.Role).AsNoTracking().Select(z => new UserModel(z)).ToList();
        }

        public UserModel GetById(int id)
        {
            var j = context.Users.Where(x => x.ID == id).Include(z => z.Role).AsNoTracking().ToList().FirstOrDefault();
            return new UserModel(j);
        }
    }
}
