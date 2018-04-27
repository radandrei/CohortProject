using BusinessLayer.Models;
using DataAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User GetByUsername(string username);
    }
}
