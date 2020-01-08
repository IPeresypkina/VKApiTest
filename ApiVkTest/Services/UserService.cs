using System;
using ApiVkTest.Model;
using Tests.Repositories;

namespace ApiVkTest.Services
{
    public class UserService
    {
        private IUsersRepository _usersRepository;

        public UserService(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public int GetAge(string id)
        {
            User userBD = _usersRepository.GetUserById(id);
            DateTime enteredDate = DateTime.Parse(userBD.bdate);
            return CalculateAge(enteredDate);
        }
        public static int CalculateAge(DateTime BirthDate)
        {
            int YearsPassed = DateTime.Now.Year - BirthDate.Year;
            if (DateTime.Now.Month < BirthDate.Day || (DateTime.Now.Month == BirthDate.Day && DateTime.Now.Day < BirthDate.Month))
                YearsPassed--;
            return YearsPassed;
        }
    }
}