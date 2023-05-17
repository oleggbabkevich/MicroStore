using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace User.Domain
{
    public interface IUserService
    {
        Task Register(User user);
        Task<User> Login(string email, string password);
    }
}
