using Newtonsoft.Json;
using ApiVkTest.Model;
using ApiVkTest.WebClient;

namespace Tests.Repositories
{
    public class UsersRepositoryMock : IUsersRepository
    {
        private string accessToken =
            "f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce";

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