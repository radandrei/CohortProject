using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccesLibrary.Models
{
    class Role
    {
        public int roleID;
        public string RoleName;
        public ICollection<User> Users { get; set; }
    }
}
