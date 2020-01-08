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
            Group group = new Group();
            if (id == "maxkorzh")
            {
                group = new Group()
                {
                    id = "maxkorzh",
                    name = "Макс Корж",
                    members_count = 1409669
                };
            }
            else if (id == "kladovayacomiksovv")
            {
                group = new Group()
                {
                    id = "kladovayacomiksovv",
                    name = "Кладовая комиксов",
                    members_count = 936802
                };
            }
            else if (id == "wolfsbrewery")
            {
                group = new Group()
                {
                    id = "wolfsbrewery",
                    name = "Волковская Пивоварня",
                    members_count = 5711
                };
            }
            return group;
        }
    }
}