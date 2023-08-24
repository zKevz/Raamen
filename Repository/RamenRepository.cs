using Raamen.Factory;
using Raamen.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Raamen.Repository
{
    public static class RamenRepository
    {
        private static readonly LocalDatabaseEntities m_Database = new LocalDatabaseEntities();

        public static List<Ramen> GetAllRamens()
        {
            return m_Database.Ramens.ToList();
        }

        public static void DeleteRamen(Ramen ramen)
        {
            m_Database.Ramens.Remove(ramen);
            m_Database.SaveChanges();
        }

        public static void InsertRamen(string ramenName, string meat, string broth, int price)
        {
            Ramen ramen = RamenFactory.CreateRamen(ramenName, meat, broth, price);
            m_Database.Ramens.Add(ramen);
            m_Database.SaveChanges();
        }

        public static bool IsRamenExistByID(int id)
        {
            return !(m_Database.Ramens.Find(id) is null);
        }

        public static bool IsRamenExistByName(string ramenName)
        {
            return m_Database.Ramens.Any(x => x.Name.Equals(ramenName, StringComparison.OrdinalIgnoreCase));
        }

        public static Ramen GetRamenByID(int id)
        {
            return m_Database.Ramens.Find(id);
        }

        public static void UpdateRamen(int id, string ramenName, string meat, string broth, int price)
        {
            Ramen ramen = GetRamenByID(id);
            ramen.Name = ramenName;
            ramen.Broth = broth;
            ramen.Price = price;
            ramen.MeatID = MeatRepository.GetMeatByName(meat).ID;

            m_Database.SaveChanges();
        }
    }
}