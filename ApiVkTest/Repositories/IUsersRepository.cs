using ApiVkTest.Model;

namespace Tests.Repositories
{
    public interface IUsersRepository
    {
        User GetUserById(string id);
        string baseURL { get; set; }
    }
}