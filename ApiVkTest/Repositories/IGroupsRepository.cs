using ApiVkTest.Model;

namespace Tests.Repositories
{
    public interface IGroupsRepository
    {
        Group GetGroupById(string id);
        string baseURL { get; set; }
    }
}