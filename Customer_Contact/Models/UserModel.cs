using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer_Contact.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public RoleModel Role { get; set; }


        public static explicit operator UserModel(UserSys userSys)
        {
            if (userSys == null)
                return null;

            return new UserModel()
            {
                Id = userSys.Id,
                Login = userSys.Login,
                Email = userSys.Email,
                Role = (RoleModel)userSys.Role
            };
        }
    }
}