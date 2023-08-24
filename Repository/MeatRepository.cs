using Raamen.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raamen.Repository
{
    public static class MeatRepository
    {
        private static readonly LocalDatabaseEntities m_Database = new LocalDatabaseEntities();

        public static List<Meat> GetMeats()
        {
            return m_Database.Meats.ToList();
        }

        public static Meat GetMeatByName(string meatName)
        {
            return m_Database.Meats.FirstOrDefault(x => x.Name == meatName);
        }
    }
}