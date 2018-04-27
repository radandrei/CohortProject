using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNet.Identity;

namespace DataAccessLayer.RepositoryModels
{
    public class IdentityUser : IUser<int>
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public IdentityUser(string username)
        {
            UserName= username;
        }
    }
}
