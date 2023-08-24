using Raamen.Controller;
using Raamen.Factory;
using Raamen.Handler;
using Raamen.Model;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class TransactionsQueuePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (user.Role.Name == RoleRepository.CustomerName)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            RefreshHandledTransactions();
            RefreshUnhandledTransactions();
        }

        private void RefreshHandledTransactions()
        {
            var list = TransactionRepository.GetAllTransactions();
            if (list.Count == 0)
            {
                HandledTransactionsInfoLabel.Text = "No handled transactions.";
            }
            else
            {
                HandledTransactionsInfoLabel.Text = "";
            }

            HandledTransactionsGridView.DataSource = list.Select(x =>
            {
                return new
                {
                    x.ID,
                    x.Date,
                    StaffName = UserRepository.GetUserByID(x.StaffID).Username,
                    CustomerName = UserRepository.GetUserByID(x.CustomerID).Username
                };
            });
            HandledTransactionsGridView.DataBind();
        }

        private void RefreshUnhandledTransactions()
        {
            if (Application["UnhandledTransactions"] is null)
            {
                Application["UnhandledTransactions"] = new List<UnhandledTransaction>();
            }

            var unhandledTransactions = (List<UnhandledTransaction>)Application["UnhandledTransactions"];
            if (unhandledTransactions.Count == 0)
            {
                UnhandledTransactionsInfoLabel.Text = "No unhandled transactions.";
            }
            else
            {
                UnhandledTransactionsInfoLabel.Text = "";
            }

            UnhandledTransactionsGridView.DataSource = unhandledTransactions.Select(x =>
            {
                return new
                {
                    x.Date,
                    CustomerName = x.Customer.Username,
                };
            });
            UnhandledTransactionsGridView.DataBind();
        }

        protected void OnUnhandledTransactionsRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (Application["UnhandledTransactions"] is null)
                {
                    Application["UnhandledTransactions"] = new List<UnhandledTransaction>();
                }


                if (!int.TryParse((string)e.CommandArgument, out int index))
                {
                    return;
                }

                var user = UserController.CheckSessionOrCookie(Session, Request);
                var unhandledTransactions = (List<UnhandledTransaction>)Application["UnhandledTransactions"];

                if (index < 0 || index >= unhandledTransactions.Count)
                {
                    return;
                }

                TransactionsHandler.HandleTransaction(user, unhandledTransactions[index]);

                unhandledTransactions.RemoveAt(index);

                RefreshHandledTransactions();
                RefreshUnhandledTransactions();
            }
        }
    }
}