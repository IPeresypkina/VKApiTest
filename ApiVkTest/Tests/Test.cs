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
            Assert.AreEqual("1.6.1998",user.bdate);
            
        }
        [Test]
        public void GetGroupFromRepositoryTest()
        {
            IGroupsRepository groupsRepository = new GroupsRepositoryVk();
            groupsRepository.baseURL = "http://localhost:8080/method/";
            Group group = groupsRepository.GetGroupById("1");
            Assert.AreEqual("ВКонтакте API", group.name);
        }

        
        [Test]
        public void GetUserFromServiceTest()//тестируем сервис с помощью мокРепозитория
        {
            IUsersRepository userRepository = new UsersRepositoryMock();
            UserService userService = new UserService(userRepository);
            int age = userService.GetAge("86031446");
            Assert.AreEqual(21, age);
        }
        
        [Test]
        public void GetGropFromServiceTest()//тестируем сервис с помощью мокРепозитория
        {
            IGroupsRepository groupsRepository = new GroupsRepositoryMock();
            GroupService groupService = new GroupService(groupsRepository);
            string popular = groupService.GetPopularGroup("maxkorzh");
            Assert.AreEqual("сверх популярна", popular);
            
            popular = groupService.GetPopularGroup("kladovayacomiksovv");
            Assert.AreEqual("популярна", popular);
            
            popular = groupService.GetPopularGroup("wolfsbrewery");
            Assert.AreEqual("не популярна", popular);
        }
        

        [Test]
        public void GetUserById()
        {
            IUsersRepository userRepository = new UsersRepositoryVk();
            userRepository.baseURL = "https://api.vk.com/method/";
            UserService userService = new UserService(userRepository);
            int age = userService.GetAge("86031446");
            Assert.AreEqual(21, age);
            
            // User user = userRepository.GetUserById("86031446");
            // Assert.AreEqual("Ирина", user.first_name);
            // Assert.AreEqual("Пересыпкина",user.last_name);
            // Assert.AreEqual("1.6.1998",user.bdate);
        }
        
        // [Test]
        // public void GetGroupById()
        // {
        //     IGroupsRepository groupRepository = new GroupsRepositoryVk();
        //     GroupService groupService = new GroupService(groupRepository);
        //     Group group = groupService.GetGroupById("1");
        //     
        //     Assert.AreEqual("ВКонтакте API", group.name);
        //     
        //     groupRepository = new GroupsRepositoryMock();
        //     groupService = new GroupService(groupRepository);
        //     group = groupService.GetGroupById("1");
        //     
        //     Assert.AreEqual("ВКонтакте API", group.name);
        // }
    }
}