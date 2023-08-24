using Raamen.Controller;
using Raamen.Model;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class HistoryPage : Page
    {
        private static List<TransactionHeader> m_Transactions;

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (user.Role.Name == RoleRepository.StaffName)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }
            else if (user.Role.Name == RoleRepository.CustomerName)
            {
                m_Transactions = TransactionRepository.GetAllTransactionsByUser(user.ID);
                if (m_Transactions.Count == 0)
                {
                    TransactionLabel.Text = "You don't have any transaction history";
                }
                else
                {
                    TransactionLabel.Text = "Transactions History";
                }

                TransactionGridView.DataSource = m_Transactions.Select(x =>
                {
                    return new
                    {
                        x.ID,
                        x.Date,
                        StaffName = UserRepository.GetUserByID(x.StaffID).Username,
                        CustomerName = UserRepository.GetUserByID(x.CustomerID).Username,
                    };
                });
                TransactionGridView.DataBind();
            }
            else
            {
                m_Transactions = TransactionRepository.GetAllTransactions();
                if (m_Transactions.Count == 0)
                {
                    TransactionLabel.Text = "No transactions history found.";
                }
                else
                {
                    TransactionLabel.Text = "Transactions History";
                }

                TransactionGridView.DataSource = m_Transactions.Select(x =>
                {
                    return new
                    {
                        x.ID,
                        x.Date,
                        StaffName = UserRepository.GetUserByID(x.StaffID).Username,
                        CustomerName = UserRepository.GetUserByID(x.CustomerID).Username,
                    };
                });
                TransactionGridView.DataBind();
            }
        }

        protected void OnTransactionRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (!int.TryParse((string)e.CommandArgument, out int index))
                {
                    return;
                }

                if (index < 0 || index >= m_Transactions.Count)
                {
                    return;
                }

                Response.Redirect($"TransactionDetailPage.aspx?ID={m_Transactions[index].ID}");
            }
        }
    }
}