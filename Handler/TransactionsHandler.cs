using Raamen.Factory;
using Raamen.Model;
using Raamen.Repository;

namespace Raamen.Handler
{
    public static class TransactionsHandler
    {
        public static void HandleTransaction(User user, UnhandledTransaction unhandledTransaction)
        {
            var transaction = TransactionFactory.CreateTransaction(unhandledTransaction.Customer.ID, user.ID, unhandledTransaction.Date);

            TransactionRepository.AddTransaction(transaction);

            foreach (var cart in unhandledTransaction.Carts)
            {
                TransactionRepository.AddTransactionDetail(TransactionFactory.CreateTransactionDetail(transaction.ID, cart));
            }
        }
    }
}