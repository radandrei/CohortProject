using DataAccessLayer.Entities;
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
            new Role{Name="Administrator"},
            new Role{Name="Patient"}
            };
            foreach (Role s in roles)
            {
                context.Roles.Add(s);
            }
            context.SaveChanges();

        }
    }
}
