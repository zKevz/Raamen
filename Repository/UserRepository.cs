using Raamen.Factory;
using Raamen.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raamen.Repository
{
    public class UserRepository
    {
        private static readonly LocalDatabaseEntities m_Database = new LocalDatabaseEntities();

        public static User GetUserByNamePassword(string username, string password)
        {
            var user = m_Database.Users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase) && x.Password.Equals(password));
            return user;
        }

        public static User GetUserByID(int id)
        {
            return m_Database.Users.Find(id);
        }

        public static User GetUserByName(string username)
        {
            return m_Database.Users.FirstOrDefault(x => x.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        }

        public static void InsertUser(string username, string password, string email, string gender)
        {
            User user = UserFactory.Create(username, password, email, gender);
            m_Database.Users.Add(user);
            m_Database.SaveChanges();
        }

        public static List<User> GetAllCustomers()
        {
            return m_Database.Users.Where(x => x.Role.Name == RoleRepository.CustomerName).ToList();
        }

        public static List<User> GetAllStaffs()
        {
            return m_Database.Users.Where(x => x.Role.Name == RoleRepository.StaffName).ToList();
        }

        public static void UpdateUser(int id, string username, string email, string gender)
        {
            var user = GetUserByID(id);
            user.Email = email;
            user.Gender = gender;
            user.Username = username;

            m_Database.SaveChanges();
        }

        public static void SaveChanges()
        {
            m_Database.SaveChanges();
        }
    }
}