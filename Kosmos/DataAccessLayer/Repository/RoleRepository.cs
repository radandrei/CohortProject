using BusinessLayer.Models;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private MedicalDBContext context;

        public RoleRepository(MedicalDBContext context)
        {
            this.context = context;
        }

        public List<RoleModel> GetAll()
        {
            return context.Roles.Select(z => new RoleModel(z)).ToList();
        }

        public RoleModel GetById(int id)
        {
            var j = context.Roles.Where(x => x.ID == id).FirstOrDefault();
            return new RoleModel(j);
        }

        public RoleModel AddOrUpdate(RoleModel role)
        {
            var changedRole = context.Roles.Where(x => x.ID == role.ID).FirstOrDefault();

            try
            {
                if (changedRole == null)
                {
                    changedRole = new Role()
                    {
                        Name = role.Name
                    };
                    context.Add(changedRole);
                }
                else
                {
                    changedRole.Name = role.Name;
                    context.Update(changedRole);
                }
            }
            catch(DbUpdateException ex)
            {
                throw new Exception("Issue with database insertion: " + ex);
            }
            
            context.SaveChanges();
            return new RoleModel(changedRole);
        }

        public void Delete(int Id)
        {
            try
            {
                Role roleToDelete = new Role() { ID = Id };
                context.Entry(roleToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database deletion: " + ex);
            }
        }
    }
}
