using NUnit.Framework;
using ApiVkTest.Model;
using ApiVkTest.Services;
using Tests.Repositories;

namespace ApiVkTest.Tests
{
    public class Test
    {
        [Test]
        public void GetUserFromRepositoryTest()//тестируем репозиторий с помощью мокСервера
        {
            IUsersRepository userRepository = new UsersRepositoryVk();
            userRepository.baseURL = "http://localhost:8080/method/";
            User user = userRepository.GetUserById("86031446");
            Assert.AreEqual("Ирина", user.first_name);
            Assert.AreEqual("Пересыпкина",user.last_name);
        }
        [Test]
        public void GetGroupFromRepositoryTest()
        {
            IGroupsRepository groupsRepository = new GroupsRepositoryVk();
            groupsRepository.baseURL = "http://localhost:8080/method/";
            Group group = groupsRepository.GetGroupById("1");
            Assert.AreEqual("ВКонтакте API", group.name);
        }
        
        // [Test]
        // public void GetUserFromServiceTest()//тестируем репозиторий с помощью мокСервера
        // {
        //     IUsersRepository userRepository = new UsersRepositoryVk();
        //     userRepository.baseURL = "http://localhost:8080/method/";
        //     User user = userRepository.GetUserById("86031446");
        //     Assert.AreEqual("Ирина", user.first_name);
        //     Assert.AreEqual("Пересыпкина",user.last_name);
        // }

        [Test]
        public void GetUserById()
        {
            IUsersRepository userRepository = new UsersRepositoryMock();
            UserService userService = new UserService(userRepository);
            User user = userService.GetUserById("86031446");
            
            Assert.AreEqual("Ирина", user.first_name);
            Assert.AreEqual("Пересыпкина",user.last_name);
            
            userRepository = new UsersRepositoryVk();
            userService = new UserService(userRepository);
            user = userService.GetUserById("86031446");
            
            Assert.AreEqual("Ирина", user.first_name);
            Assert.AreEqual("Пересыпкина", user.last_name);
        }
        
        [Test]
        public void GetGroupById()
        {
            
            IGroupsRepository groupRepository = new GroupsRepositoryVk();
            GroupService groupService = new GroupService(groupRepository);
            Group group = groupService.GetGroupById("1");
            
            Assert.AreEqual("ВКонтакте API", group.name);
            
            groupRepository = new GroupsRepositoryMock();
            groupService = new GroupService(groupRepository);
            group = groupService.GetGroupById("1");
            
            Assert.AreEqual("ВКонтакте API", group.name);
        }
    }
}