using System;
using System.Collections.Generic;
using System.Text;
using DataAccessLayer.Entities;

namespace BusinessLayer.Models
{
    public class RoleModel
    {
        public RoleModel(Role role)
        {
            ID = role.Id;
            Name = role.Name;
        }

        public RoleModel()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
