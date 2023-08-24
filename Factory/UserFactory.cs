using Raamen.Model;
using Raamen.Repository;
using System;

namespace Raamen.Factory
{
    public class UserFactory
    {
        public static User Create(string username, string password, string email, string gender)
        {
            int roleID;
            if (username.Equals("admin", StringComparison.OrdinalIgnoreCase))
            {
                roleID = RoleRepository.GetAdminRole().ID;
            }
            else if (username.Equals("staff", StringComparison.OrdinalIgnoreCase))
            {
                roleID = RoleRepository.GetStaffRole().ID;
            }
            else
            {
                roleID = RoleRepository.GetCustomerRole().ID;
            }

            return new User()
            {
                Username = username,
                Password = password,
                Email = email,
                Gender = gender,
                RoleID = roleID
            };
        }
    }
}