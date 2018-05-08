using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class AllergicReactionModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public AllergicReactionModel(AllergicReaction allergicReaction)
        {
            ID = allergicReaction.ID;
            Name = allergicReaction.Name;
        }
    }
}
