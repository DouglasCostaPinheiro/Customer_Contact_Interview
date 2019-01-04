using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Customer_Contact.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        public static explicit operator RoleModel(UserRole userRole)
        {
            return new RoleModel()
            {
                Id = userRole.Id,
                Name = userRole.Name,
                IsAdmin = userRole.IsAdmin
            };
        }
    }
}