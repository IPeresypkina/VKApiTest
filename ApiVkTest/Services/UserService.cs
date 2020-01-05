using ApiVkTest.Model;
using Tests.Repositories;

namespace ApiVkTest.Services
{
    public class UserService
    {
        private IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public User GetUserById(string id)
        {
            return _usersRepository.GetUserById(id);
        }
    }
}