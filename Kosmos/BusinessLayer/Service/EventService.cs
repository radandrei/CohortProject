﻿using BusinessLayer.Models;
using DataAccessLayer;
using DataAccessLayer.Entities;
using DataAccessLayer.Repository;
using DataAccessLayer.RepositoryInterfaces;
using System.Collections.Generic;


namespace BusinessLayer.Service
{
    public class EventService
    {
        private IEventRepository EventRepository;

        public EventService(MedicalDBContext context)
        {
            EventRepository = new EventRepository(context);
        }

        public List<EventModel> getEventsByMedicalChart(int medicalChartId)
        {
            List<EventModel> EventList = new List<EventModel>();
            List<Event> returnList = EventRepository.GetAllByMedicalChart(medicalChartId);
            foreach (Event Event in returnList)
                EventList.Add(new EventModel(Event));
            return EventList;

        }
    }
}
