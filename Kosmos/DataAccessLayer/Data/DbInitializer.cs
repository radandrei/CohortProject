using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MedicalDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any students.
            if (context.Users.Any())
            {
                return;   // DB has been seeded
            }

            var roles = new Role[]
            {
            new Role{Name="Admin"}
            };
            foreach (Role s in roles)
            {
                context.Roles.Add(s);
            }
            context.SaveChanges();


            var users = new User[]
            {
            new User{Username="Gabriel",Password="raducuu",RoleID=context.Roles.First().ID}
            };
            foreach (User s in users)
            {
                context.Users.Add(s);
            }
            context.SaveChanges();
        }
    }
}
