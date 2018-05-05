using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class EventTypeModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //public ICollection<EventModel> Event { get; set; }

        public EventTypeModel(EventType eventType)
        {
            ID = eventType.ID;
            Name = eventType.Name;

        }
    }
}
