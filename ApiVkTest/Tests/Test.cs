using MockServer;
using NUnit.Framework;
using ApiVkTest.Model;
using Tests.Repositories;

namespace ApiVkTest.Tests
{
    public class Test
    {
        [Test]
        public void GetUserById()
        {
            //Server server = new Server();

            IUsersRepository userRepository = new UsersRepositoryMock();
            User user = userRepository.GetUserById("7438294");
            
            Assert.AreEqual("Ирина", user.first_name);
            Assert.AreEqual("Пересыпкина",user.last_name);
            
            
            userRepository = new UsersRepositoryVk();
            user = userRepository.GetUserById("7438294");
            
            Assert.AreEqual("Ирина", user.first_name);
            Assert.AreEqual("Пересыпкина",user.last_name);
            
        }
    }
}