using DataAccessLayer.Entities;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccessLayer.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private MedicalDBContext context;

        public RoleRepository(MedicalDBContext context)
        {
            this.context = context;
        }

        public List<Role> GetAll()
        {
            return context.Roles.ToList();
        }

        public Role GetById(int id)
        {
            var j = context.Roles.Where(x => x.Id == id).FirstOrDefault();
            return j;
        }

        public Role AddOrUpdate(Role role)
        {
            Role changedRole;
            changedRole = context.Roles.Where(x => x.Id == role.Id).FirstOrDefault();

            try
            {
                if (changedRole == null)
                {
                    changedRole.Name = role.Name;
                    context.Update(changedRole);
                }
                else
                {
                    changedRole = new Role()
                    {
                        Name = role.Name
                    };
                    context.Add(changedRole);
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database insertion: " + ex);
            }

            context.SaveChanges();
            return changedRole;
        }

        public void Delete(int Id)
        {
            try
            {
                Role roleToDelete = new Role() { Id = Id };
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
