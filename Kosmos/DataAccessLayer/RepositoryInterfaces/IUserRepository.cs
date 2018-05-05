using DataAccessLayer.Entities;

namespace BusinessLayer.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        User CreateUser(User user);
        User GetByUsername(string username);
    }
}
