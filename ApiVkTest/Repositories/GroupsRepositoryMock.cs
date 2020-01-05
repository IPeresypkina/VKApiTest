using Newtonsoft.Json;
using ApiVkTest.Model;
using ApiVkTest.WebClient;

namespace Tests.Repositories
{
    public class GroupsRepositoryMock: IGroupsRepository
    {
        private string url = "http://localhost:8080/method/";
        
        public Group GetGroupById(string id)
        {
            string request = $"{url}groups/getById/{id}";
            WebClient webHelper = new WebClient();
            string json = webHelper.SendRequest(request, "GET");
            return Parse(json);
        }
        
        private Group Parse(string json)
        {
            return JsonConvert.DeserializeObject<Group>(json);
        }
    }
}