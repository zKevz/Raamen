using Raamen.Controller;
using Raamen.Model;
using Raamen.Repository;
using System;
using System.Linq;
using System.Web.UI;

namespace Raamen.View
{
    public partial class TransactionDetailPage : Page
    {
        private int TransactionID;

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (Request.QueryString["ID"] is null)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!int.TryParse(Request.QueryString["ID"], out TransactionID))
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!TransactionRepository.IsTransactionExistByID(TransactionID))
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            var num = 1;
            var transaction = TransactionRepository.GetTransactionByID(TransactionID);

            TransactionInfoLabel1.Text = $"Transaction #{TransactionID}";
            TransactionInfoLabel2.Text = $"Customer : {UserRepository.GetUserByID(transaction.CustomerID).Username}";
            TransactionInfoLabel3.Text = $"Staff : {UserRepository.GetUserByID(transaction.StaffID).Username}";
            TransactionInfoLabel4.Text = $"Date : {transaction.Date}";

            TransactionDetailGridView.DataSource = transaction.TransactionDetails.Select(x =>
            {
                return new
                {
                    x.Quantity,
                    Number = num++,
                    RamenName = RamenRepository.GetRamenByID(x.RamenID).Name,
                };
            });
            TransactionDetailGridView.DataBind();
        }

        protected void OnBackButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("HistoryPage.aspx");
        }
    }
}