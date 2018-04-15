using DataAccessLayer.Entities;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace BusinessLayer.Models
{
    public class MedicalChartModel
    {
        public int ID { get; set; }
        public DateTime CreationDate { get; set; }
        public string Notes { get; set; }

        public ICollection<EventModel> Events { get; set; }
        public ICollection<ContraindicationModel> Contraindications { get; set; }
        public ICollection<AllergyModel> Allergies { get; set; }
        public ICollection<MedicalChartHistoryModel> ChartModifications { get; set; }

        public MedicalChartModel(MedicalChart medicalChart)
        {
            ID = medicalChart.ID;
            CreationDate = medicalChart.CreationDate;
            Notes = medicalChart.Notes;

            Events = new Collection<EventModel>();
            foreach(Event E in medicalChart.Events)
            {
                Events.Add(new EventModel(E));
            }


            Contraindications = new Collection<ContraindicationModel>();
            foreach (Contraindication C in medicalChart.Contraindications)
            {
                Contraindications.Add(new ContraindicationModel(C));
            }


            Allergies = new Collection<AllergyModel>();
            foreach (Allergy A in medicalChart.Allergies)
            {
                Allergies.Add(new AllergyModel(A));
            }
        }
    }
}
