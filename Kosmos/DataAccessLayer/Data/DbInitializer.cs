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

            var cabinets = new Cabinet[]
            {
                new Cabinet{Name="Cluj", DoctorPosition="Resident",Address="Cluj-Napoca"}
            };

            foreach(Cabinet c in cabinets)
            {
                context.Cabinets.Add(c);
            }

            var roles = new Role[]
            {
            new Role{Name="Administrator"},
            new Role{Name="Patient"},
            new Role{Name="Medic"},
            new Role{Name="Assistant"}
            };
            foreach (Role s in roles)
            {
                context.Roles.Add(s);
            }
            context.SaveChanges();

            context.MedicalCharts.Add(new MedicalChart()
            {
                CreationDate = DateTime.Today,
                Notes = ""
            });

            context.PersonalData.Add(new PersonalData()
            {
                Birthdate=new DateTime(1996,12,12)
            });

            context.PersonalData.Add(new PersonalData()
            {
                Birthdate = new DateTime(1996, 12, 12)
            });

            context.PersonalData.Add(new PersonalData()
            {
                Birthdate = new DateTime(1996, 12, 12)
            });

            context.Users.Add(new User()
            {
                Username = "cipri",
                Password = "$KCOA$V1$10000$bRyC0Ll5o+5iHbKMDkgR1Dfqj73bu6RTRUz3viH234lBxGn5",
                RoleId = 1
            });

            context.Users.Add(new User()
            {
                Username = "roxana",
                Password = "$KCOA$V1$10000$bRyC0Ll5o+5iHbKMDkgR1Dfqj73bu6RTRUz3viH234lBxGn5",
                RoleId = 2
            });

            context.Users.Add(new User()
            {
                Username = "dragos",
                Password = "$KCOA$V1$10000$bRyC0Ll5o+5iHbKMDkgR1Dfqj73bu6RTRUz3viH234lBxGn5",
                RoleId = 3
            });

            context.AllergicReactions.Add(new AllergicReaction()
            {
                Name = "Parmesan"
            });

            context.EventTypes.Add(new EventType()
            {
                Name="Test"
            });

            context.Diagnoses.Add(new Diagnosis()
            {
                Name = "Minor cold"
            });

            context.Medicine.Add(new Medicine()
            {
                Name = "Tylenol"
            });

            context.SaveChanges();

            context.Prescriptions.Add(new Prescription()
            {
                DiagnosisID = 1,
                MedicalChartID = 1,
                Notes = "Twice a day for one week",
                Date=DateTime.Today
            });

            context.Allergies.Add(new Allergy()
            {
                AllergicReactionID=1,
                MedicalChartID=1
            });

            context.Events.Add(new Event()
            {
                MedicalChartID = 1,
                StartDate = new DateTime(2018, 1, 1),
                EndDate = new DateTime(2018, 2, 2),
                DiagnosisID = 1,
                Name = "Bi-anual check-up",
                Observations = "A minor cold",
                TypeID = 1
            });

            context.Persons.Add(new Person()
            {
                Active = true,
                CabinetID = 1,
                FirstName = "Ciprian",
                LastName = "Pintilei",
                MedicalChartID = 1,
                PersonalDataID = 1,
                UserId = 1
            });

            context.Persons.Add(new Person()
            {
                Active = true,
                CabinetID = 1,
                FirstName = "Roxana",
                LastName = "Pamparau",
                MedicalChartID = 1,
                PersonalDataID = 2,
                UserId = 2
            });

            context.Persons.Add(new Person()
            {
                Active = true,
                CabinetID = 1,
                FirstName = "Dragos",
                LastName = "Onet",
                MedicalChartID = 1,
                PersonalDataID = 3,
                UserId = 3
            });

            context.SaveChanges();

            context.PrescribedMedicine.Add(new PrescribedMedicine()
            {
                MedicineID = 1,
                PrescriptionID = 1
            });

            context.SaveChanges();
        }
    }
}
