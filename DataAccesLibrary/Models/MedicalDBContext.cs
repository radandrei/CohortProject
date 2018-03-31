using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLibrary.Models
{
    class MedicalDBContext : DbContext
    {
        public SchoolContext() : base("medicaloffice")
        {
            Database.SetInitializer<MedicalDBContext>(new CreateDatabaseIfNotExists<MedicalDBContext>());
            //Database.SetInitializer<MedicalDBContext>(new DropCreateDatabaseIfModelChanges<MedicalDBContext>());
            //Database.SetInitializer<MedicalDBContext>(new DropCreateDatabaseAlways<MedicalDBContext>());
            //Database.SetInitializer<MedicalDBContext>(new SchoolDBInitializer());
            //Database.SetInitializer<MedicalDBContext>(null);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
