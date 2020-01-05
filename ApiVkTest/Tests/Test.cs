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

            IUsersRepository userRepository = new UsersRepositoryMock();
            User user = userRepository.GetUserById("86031446");
            
            Assert.AreEqual("Ирина", user.first_name);
            Assert.AreEqual("Пересыпкина",user.last_name);
            
            userRepository = new UsersRepositoryVk();
            user = userRepository.GetUserById("86031446");
            
            Assert.AreEqual("Ирина", user.first_name);
            Assert.AreEqual("Пересыпкина",user.last_name);
            
        }
    }
}