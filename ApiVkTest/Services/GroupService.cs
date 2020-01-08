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

        public string GetPopularGroup(string id)
        {
            Group popularGroup = _groupsRepository.GetGroupById(id);
            string popular;
            if (popularGroup.members_count < 100000)
                popular = "не популярна";
            else if (popularGroup.members_count < 1000000)
                popular = "популярна";
            else popular = "сверх популярна";
            return popular;
        }
        
    }
}