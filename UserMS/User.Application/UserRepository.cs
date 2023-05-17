using User.Domain;

namespace User.Application
{
    public class UserRepository : IUserRepository
    {
        public Task CreateUser(Domain.User user)
        {
            throw new NotImplementedException();
        }

        public Task<Domain.User> GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }
    }
}
