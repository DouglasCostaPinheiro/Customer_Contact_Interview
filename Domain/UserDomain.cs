using Entities;
using Infra;
using System.Collections.Generic;

namespace Domain
{
    public static class UserDomain
    {
        private static UserRepository _repo = new UserRepository();

        public static UserSys GetUserById(int id)
        {
            return _repo.GetUserById(id);
        }

        public static UserSys GetUserAuthentication(string login, string password)
        {
            return _repo.GetUserAuthentication(login, password);
        }

        public static IEnumerable<UserSys> ListUsers()
        {
            return _repo.ListUsers();
        }
    }
}
