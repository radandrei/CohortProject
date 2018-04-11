using DataAccessLayer.Models;
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

        public UserModel(User user)
        {
            this.ID = user.ID;
            this.Username = user.Username;
            Role = new RoleModel(user.Role);
        }
    }
}
