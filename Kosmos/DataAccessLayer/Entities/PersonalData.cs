using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Models
{
    public class PersonalData
    {
        public int ID { get; set; }
        public DateTime Birthdate { get; set; }

        public Person Person { get; set; }
    }
}
