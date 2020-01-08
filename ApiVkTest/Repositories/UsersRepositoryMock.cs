using Newtonsoft.Json;
using ApiVkTest.Model;
using ApiVkTest.WebClient;

namespace Tests.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        //private string url = "http://localhost:8080/method/";
        public string baseURL { get; set; }
        public User GetUserById(string id)
        {
            User user = new User()
            {
                id = "86031446",
                first_name = "Ирина",
                last_name = "Пересыпкина",
                is_closed = false,
                bdate = "1.6.1998"
            };
            return user;
        }
    }
}