namespace User.Domain
{
    public interface IUserRepository
    {
        Task<User> GetUserByEmail(string email);
        Task CreateUser(User user);
    }
}
