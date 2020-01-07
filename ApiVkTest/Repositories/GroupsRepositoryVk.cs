using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ApiVkTest.Model;
using ApiVkTest.WebClient;

namespace Tests.Repositories
{
    public class GroupsRepositoryVk: IGroupsRepository
    {
        private string accessToken =
            "f9ec652d9ad60f44ad77ae7b2533583702978c976c77dff5de9efad7d53056e23ec1010ed7d7b32ba25ce";

        //private string url = "https://api.vk.com/method/";
        public string baseURL { get; set; }
        public Group GetGroupById(string id)
        {
            string request = $"{baseURL}groups.getById?group_id={id}&access_token={accessToken}&v=5.103";
            WebClient webHelper = new WebClient();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }
        
        private Group Parse(string json)
        {
            JObject groupJObject = JObject.Parse(json);
            Group result;
            if (groupJObject.First.Path == "response")
            {
                JToken groupInfo = groupJObject["response"][0];
                Group group = new Group();
                group.id = groupInfo["id"].ToString();
                group.name = groupInfo["name"].ToString();
                result = group;
            }
            else
                result = JsonConvert.DeserializeObject<Group>(json);
            return result;
        }
    }
}