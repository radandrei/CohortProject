using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using DataAccessLayer.RepositoryInterfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccessLayer.Repository
{
    public class EventRepository : IEventRepository
    {
        MedicalDBContext context;
        public EventRepository(MedicalDBContext context)
        {
            this.context = context;
        }
        public Event AddOrUpdate(Event Event)
        {
            Event changedEvent;

            try
            {
                if (Event.ID != 0)
                {
                    changedEvent = context.Events.Where(x => x.ID == Event.ID).FirstOrDefault();
                    changedEvent.StartDate = Event.StartDate;
                    changedEvent.EndDate = Event.EndDate;
                    changedEvent.Name = Event.Name;
                    changedEvent.Observations = Event.Observations;
                    changedEvent.Type = Event.Type;
                    changedEvent.Diagnosis = Event.Diagnosis;
                    context.Update(changedEvent);
                }
                else
                {
                    changedEvent = new Event()
                    {
                        StartDate = Event.StartDate,
                        EndDate = Event.EndDate,
                        Name = Event.Name,
                        Observations = Event.Observations,
                        Type = Event.Type,
                        Diagnosis = Event.Diagnosis
                };
                    context.Add(changedEvent);
                }
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database insertion: " + ex);
            }

            context.SaveChanges();
            return changedEvent;
        }

        public void Delete(int Id)
        {
            try
            {
                Event EventToDelete = new Event() { ID = Id };
                context.Entry(EventToDelete).State = EntityState.Deleted;
                context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                throw new Exception("Issue with database deletion: " + ex);
            }
        }

        public List<Event> GetAll()
        {
            return context.Events.ToList();
        }

        public Event GetById(int Id)
        {
            var j = context.Events.Where(x => x.ID == Id).FirstOrDefault();
            return j;
        }

        public List<Event> GetAllByMedicalChart(int medicalChartId)
        {
            return context.Events.Where(x => x.MedicalChartID == medicalChartId)
               .OrderByDescending(x=>x.EndDate)
                .Include(x => x.Type).Include(x => x.Diagnosis).Include(x=>x.Diagnosis.Prescription).Include(x=>x.Diagnosis.Prescription).AsNoTracking().ToList();
        }
    }
}
