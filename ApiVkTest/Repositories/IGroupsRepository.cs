using ApiVkTest.Model;

namespace Tests.Repositories
{
    public interface IGroupsRepository
    {
        Group GetGroupById(string id);
    }
}