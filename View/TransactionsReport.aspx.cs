using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Raamen.Controller;
using Raamen.Repository;
using System;
using System.Linq;
using System.Web.UI;

namespace Raamen.View
{
    public partial class TransactionsReport : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (user.Role.Name != RoleRepository.AdminName)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            var dataSet = new DataSet();
            var ramens = RamenRepository.GetAllRamens();
            var transactionHeaders = TransactionRepository.GetAllTransactions();

            foreach (var ramen in ramens)
            {
                var ramenRow = dataSet.Ramens.NewRow();
                ramenRow["ID"] = ramen.ID;
                ramenRow["Name"] = ramen.Name;
                ramenRow["Broth"] = ramen.Broth;
                ramenRow["Price"] = ramen.Price;
                ramenRow["MeatID"] = ramen.MeatID;

                dataSet.Ramens.Rows.Add(ramenRow);
            }

            foreach (var transactionHeader in transactionHeaders)
            {
                var transactionHeaderRow = dataSet.TransactionHeaders.NewRow();
                transactionHeaderRow["ID"] = transactionHeader.ID;
                transactionHeaderRow["CustomerID"] = transactionHeader.CustomerID;
                transactionHeaderRow["StaffID"] = transactionHeader.StaffID;
                transactionHeaderRow["Date"] = transactionHeader.Date;

                dataSet.TransactionHeaders.Rows.Add(transactionHeaderRow);

                foreach (var transactionDetail in transactionHeader.TransactionDetails)
                {
                    var transactionDetailRow = dataSet.TransactionDetails.NewRow();
                    transactionDetailRow["HeaderID"] = transactionDetail.HeaderID;
                    transactionDetailRow["RamenID"] = transactionDetail.RamenID;
                    transactionDetailRow["Quantity"] = transactionDetail.Quantity;

                    dataSet.TransactionDetails.Rows.Add(transactionDetailRow);
                }
            }

            var crystalReport = new CrystalReport();
            crystalReport.SetDataSource(dataSet);

            var sum = transactionHeaders.Sum(transaction => transaction.TransactionDetails.Sum(detail => detail.Quantity * detail.Ramen.Price));
            var grandTotalText = (TextObject)crystalReport.ReportDefinition.ReportObjects["GrandTotalText"];
            grandTotalText.Text = $"Grand Total: {sum}";

            CrystalReportViewer.ReportSource = crystalReport;
            CrystalReportViewer.DataBind();
        }
    }
}