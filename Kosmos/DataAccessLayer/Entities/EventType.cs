using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class EventType
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public ICollection<Event> Event { get; set; }
    }
}
