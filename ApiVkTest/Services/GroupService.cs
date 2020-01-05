using ApiVkTest.Model;
using Tests.Repositories;

namespace ApiVkTest.Services
{
    public class GroupService
    {
        private IGroupsRepository _groupsRepository;

        public GroupService(IGroupsRepository groupsRepository)
        {
            _groupsRepository = groupsRepository;
        }

        public Group GetGroupById(string id)
        {
            return _groupsRepository.GetGroupById(id);
        }
    }
}