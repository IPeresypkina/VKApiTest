using Newtonsoft.Json;
using ApiVkTest.Model;
using ApiVkTest.WebClient;

namespace Tests.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        private string url = "http://localhost:8080/method/";
        
        public User GetUserById(string id)
        {
            string request = $"{url}users/get/{id}";
            WebClient webHelper = new WebClient();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            return JsonConvert.DeserializeObject<User>(json);
        }
    }
}