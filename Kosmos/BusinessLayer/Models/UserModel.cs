using DataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public RoleModel Role { get; set; }
        public PersonModel Person { get; set; }

        public UserModel()
        {

        }

        public UserModel(User user)
        {
            this.ID = user.Id;
            this.Username = user.Username;
            Role = new RoleModel(user.Role);
            if (user.Person!=null)
                Person = new PersonModel(user.Person);
        }
    }
}
