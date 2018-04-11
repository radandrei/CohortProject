using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IUserRepository : IBaseRepository<UserModel>
    {
        List<UserModel> GetAll();

        UserModel GetById(int id);
    }
}
