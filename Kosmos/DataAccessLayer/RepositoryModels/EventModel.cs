using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class EventModel
    {
        public int ID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Name { get; set; }
        public string Observations { get; set; }

        //public MedicalChartModel MedicalChart { get; set; }
        public DiagnosisModel Diagnosis { get; set; }
        public EventTypeModel Type { get; set; }

        public EventModel(Event Event){
            ID = Event.ID;
            StartDate = Event.StartDate;
            EndDate = Event.EndDate;
            Name = Event.Name;
            Observations = Event.Observations;

            //MedicalChart = new MedicalChartModel(Event.MedicalChart);
            if(Event.Diagnosis!=null)
                Diagnosis = new DiagnosisModel(Event.Diagnosis);
            if(Event.Type!=null)
                Type = new EventTypeModel(Event.Type);
        }
    }
}
