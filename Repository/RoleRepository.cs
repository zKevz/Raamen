using Raamen.Model;
using System.Linq;

namespace Raamen.Repository
{
    public class RoleRepository
    {
        public const string AdminName = "Admin";
        public const string StaffName = "Staff";
        public const string CustomerName = "Customer";

        private static readonly LocalDatabaseEntities m_Database = new LocalDatabaseEntities();

        public static Role GetAdminRole()
        {
            return m_Database.Roles.FirstOrDefault(x => x.Name == AdminName);
        }

        public static Role GetStaffRole()
        {
            return m_Database.Roles.FirstOrDefault(x => x.Name == StaffName);
        }

        public static Role GetCustomerRole()
        {
            return m_Database.Roles.FirstOrDefault(x => x.Name == CustomerName);
        }
    }
}