using User.Domain;
namespace User.Application
{

    public class UserService: IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Register(User.Domain.User user)
        {
            // TODO: Hash password before saving and validate input
            await _userRepository.CreateUser(user);
        }

        public async Task<User.Domain.User> Login(string email, string password)
        {
            // TODO: Compare hashed password and validate input
            return await _userRepository.GetUserByEmail(email);
        }
    }
}