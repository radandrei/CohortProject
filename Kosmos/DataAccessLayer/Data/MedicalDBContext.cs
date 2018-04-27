using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace DataAccessLayer
{
    public class MedicalDBContext : DbContext
    {
        public MedicalDBContext(DbContextOptions<MedicalDBContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<AllergicReaction> AllergicReactions { get; set; }
        public DbSet<Allergy> Allergies { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Cabinet> Cabinets { get; set; }
        public DbSet<Contraindication> Contraindications { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<MedicalChart> MedicalCharts { get; set; }
        public DbSet<MedicalChartHistory> MedicalChartHistory { get; set; }
        public DbSet<MedicalData> MedicalData { get; set; }
        public DbSet<Medicine> Medicine { get; set; }
        public DbSet<Person> Persons { get; set; }
        public DbSet<PersonalData> PersonalData { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<EventType> EventTypes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Role>().ToTable("Role");
            modelBuilder.Entity<AllergicReaction>().ToTable("AllergicReaction");
            modelBuilder.Entity<Allergy>().ToTable("Allergy");
            modelBuilder.Entity<Appointment>().ToTable("Appointment");
            modelBuilder.Entity<Cabinet>().ToTable("Cabinet");
            modelBuilder.Entity<Contraindication>().ToTable("Contraindication");
            modelBuilder.Entity<Diagnosis>().ToTable("Diagnosis");
            modelBuilder.Entity<Event>().ToTable("Event");
            modelBuilder.Entity<MedicalChart>().ToTable("MedicalChart");
            modelBuilder.Entity<MedicalChartHistory>().ToTable("MedicalChartHistory");
            modelBuilder.Entity<MedicalData>().ToTable("MedicalData");
            modelBuilder.Entity<Medicine>().ToTable("Medicine");
            modelBuilder.Entity<Person>().ToTable("Person");
            modelBuilder.Entity<PersonalData>().ToTable("PersonalData");
            modelBuilder.Entity<Prescription>().ToTable("Prescription");
            modelBuilder.Entity<EventType>().ToTable("EventType");

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
            modelBuilder.Entity<User>()
                  .HasOne(a => a.Person)
                  .WithOne(b => b.User)
                  .HasForeignKey<Person>(b => b.UserId);
        }

    }
}
