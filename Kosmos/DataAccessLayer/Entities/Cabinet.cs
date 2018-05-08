using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Cabinet
    {
        public int ID { get; set; }
        public string DoctorPosition { get; set; }

        public ICollection<Person> People { get; set; }
    }
}
