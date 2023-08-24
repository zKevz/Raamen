using Raamen.Model;
using System;

namespace Raamen.Factory
{
    public static class TransactionFactory
    {
        public static TransactionHeader CreateTransaction(int customerID, int staffID, DateTime date)
        {
            return new TransactionHeader()
            {
                Date = date,
                StaffID = staffID,
                CustomerID = customerID,
            };
        }

        public static TransactionDetail CreateTransactionDetail(int id, RamenCart cart)
        {
            return new TransactionDetail()
            {
                HeaderID = id,
                RamenID = cart.Ramen.ID,
                Quantity = cart.Quantity,
            };
        }
    }
}