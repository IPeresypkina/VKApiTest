using Newtonsoft.Json;
using ApiVkTest.Model;
using ApiVkTest.WebClient;

namespace Tests.Repositories
{
    public class GroupsRepositoryMock: IGroupsRepository
    {
        //private string url = "http://localhost:8080/method/";
        public string baseURL { get; set; }
        public Group GetGroupById(string id)
        {
            Group group = new Group()
            {
                id = "1",
                name = "ВКонтакте API"
            };
            return group;
        }
    }
}