using LoginSystemManagement.Entity;

namespace LoginSystemManagement.IRepository
{
    public interface IUserRepository
    {
        Task<User> UserRegister(User user);
         Task<User> GetUserName(string username);
        Task<List<User>> GetAllUsers();
    }
}
