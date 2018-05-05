using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLayer.Entities
{
    public class Event
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Observations { get; set; }
        public int TypeID { get; set; }
        public int DiagnosisID { get; set; }
        public int MedicalChartID { get; set; }

        public MedicalChart MedicalChart { get; set; }
        public Diagnosis Diagnosis { get; set; }
        public EventType Type { get; set; }

    }
}
