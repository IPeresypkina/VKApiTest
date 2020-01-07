using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ApiVkTest.Model;
using ApiVkTest.WebClient;

namespace Tests.Repositories
{
    public class UsersRepositoryVk: IUsersRepository
    {
        private string accessToken =
            "f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce";

        //private string url = "https://api.vk.com/method/";
        public string baseURL { get; set; }
        
        public User GetUserById(string id)
        {
            string request = $"{baseURL}users.get?users_ids={id}&access_token={accessToken}&v=5.103";
            WebClient webHelper = new WebClient();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }

        private User Parse(string json)
        {
            JObject userJObject = JObject.Parse(json);
            User result;
            if (userJObject.First.Path == "response")
            {
                JToken userInfo = userJObject["response"][0];
                User user = new User();
                user.id = userInfo["id"].ToString();
                user.first_name = userInfo["first_name"].ToString();
                user.last_name = userInfo["last_name"].ToString();
                user.is_closed = (bool)userInfo["is_closed"];
                result = user;
            }
            else
                result = JsonConvert.DeserializeObject<User>(json);
            return result;
        }
    }
}