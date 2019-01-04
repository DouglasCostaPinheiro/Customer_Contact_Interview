using Dapper;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Infra
{
    public class UserRepository : Repository
    {
        public UserRepository() : base() { }

        public UserSys GetUserById(int id)
        {
            _conn.Open();

            var user = _conn.QueryFirst<UserSys>("SELECT *, HASHBYTES('SHA2_256',PASSWORD) EncPwd FROM USERSYS WHERE Id = @Id", new { Id = id });

            _conn.Close();

            return user;
        }

        public UserSys GetUserAuthentication(string login, string password)
        {
            byte[] result = null;

            using (SHA256 sha256 = SHA256Managed.Create())
            {
                Encoding enc = Encoding.UTF8;
                result = sha256.ComputeHash(enc.GetBytes(password));
            }

            _conn.Open();

            var user = _conn.Query<UserSys, UserRole, UserSys>(@"SELECT *, HASHBYTES('SHA2_256',PASSWORD) EncPwd FROM USERSYS LEFT JOIN USERROLE ON USERROLE.ID = USERSYS.USERROLEID WHERE Login = @Login AND HASHBYTES('SHA2_256',PASSWORD) = @EncPwd", (userSys, userRole) => { userSys.Role = userRole; return userSys; }, new { Login = login, EncPwd = result });

            _conn.Close();

            return user.FirstOrDefault();
        }

        public IEnumerable<UserSys> ListUsers()
        {
            _conn.Open();

            var user = _conn.Query<UserSys, UserRole, UserSys>(@"SELECT *, HASHBYTES('SHA2_256',PASSWORD) EncPwd FROM USERSYS LEFT JOIN USERROLE ON USERROLE.ID = USERSYS.USERROLEID", (userSys, userRole) => { userSys.Role = userRole; return userSys; });

            _conn.Close();

            return user;
        }
    }
}
