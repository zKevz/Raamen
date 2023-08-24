using Raamen.Controller;
using Raamen.Repository;
using System;

namespace Raamen.View
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user == null)
            {
                NonGuestNav.Visible = false;
                return;
            }

            LoginButton.Visible = false;
            RegisterButton.Visible = false;

            if (user.Role.Name == RoleRepository.CustomerName)
            {
                ManageRamenButton.Visible = false;
                OrderQueueButton.Visible = false;
                ReportButton.Visible = false;
            }
            else if (user.Role.Name == RoleRepository.StaffName)
            {
                OrderRamenButton.Visible = false;
                HistoryButton.Visible = false;
                ReportButton.Visible = false;
            }
            else if (user.Role.Name == RoleRepository.AdminName)
            {
                OrderRamenButton.Visible = false;
            }
        }

        protected void OnLoginButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("LoginPage.aspx");
        }

        protected void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("RegisterPage.aspx");
        }

        protected void OnHomeButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("HomePage.aspx");
        }

        protected void OnOrderRamenButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("OrderRamenPage.aspx");
        }

        protected void OnProfileButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("ProfilePage.aspx");
        }

        protected void OnHistoryButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("HistoryPage.aspx");
        }

        protected void OnManageRamenButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamenPage.aspx");
        }

        protected void OnOrderQueueButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("TransactionsQueuePage.aspx");
        }

        protected void OnReportButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("TransactionsReport.aspx");
        }

        protected void OnLogoutButtonClicked(object sender, EventArgs e)
        {
            Session["User"] = null;

            if (!(Request.Cookies["Cookie_Username"] is null) && !(Request.Cookies["Cookie_Password"] is null))
            {
                Response.Cookies["Cookie_Username"].Expires = DateTime.Now;
                Response.Cookies["Cookie_Password"].Expires = DateTime.Now;
            }

            Response.Redirect("LoginPage.aspx");
        }
    }
}