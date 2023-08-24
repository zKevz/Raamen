using Raamen.Model;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;

namespace Raamen.Repository
{
    public static class TransactionRepository
    {
        private static readonly LocalDatabaseEntities m_Database = new LocalDatabaseEntities();

        public static List<TransactionHeader> GetAllTransactions()
        {
            return m_Database.TransactionHeaders.ToList();
        }

        public static List<TransactionHeader> GetAllTransactionsByUser(int userID)
        {
            return m_Database.TransactionHeaders.Where(x => x.User.ID == userID).ToList();
        }

        public static void AddTransaction(TransactionHeader transactionHeader)
        {
            m_Database.TransactionHeaders.Add(transactionHeader);
            m_Database.SaveChanges();
        }

        public static void AddTransactionDetail(TransactionDetail transactionDetail)
        {
            m_Database.TransactionDetails.Add(transactionDetail);
            m_Database.SaveChanges();
        }

        public static bool IsTransactionExistByID(int transactionID)
        {
            return !(m_Database.TransactionHeaders.Find(transactionID) is null);
        }

        public static TransactionHeader GetTransactionByID(int transactionID)
        {
            return m_Database.TransactionHeaders.Include(x => x.TransactionDetails).FirstOrDefault(x => x.ID == transactionID);
        }

        public static List<TransactionDetail> GetTransactionDetailsByID(int transactionID)
        {
            return m_Database.TransactionDetails.Where(x => x.HeaderID == transactionID).ToList();
        }
    }
}