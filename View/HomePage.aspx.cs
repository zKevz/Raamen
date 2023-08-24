using Raamen.Controller;
using Raamen.Repository;
using System;
using System.Linq;
using System.Web.UI;

namespace Raamen.View
{
    public partial class HomePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            RoleHeader.InnerText = $"Your Role: {user.Role.Name}";

            if (user.Role.Name == RoleRepository.StaffName || user.Role.Name == RoleRepository.AdminName)
            {
                var list = UserRepository.GetAllCustomers();
                if (list.Count == 0)
                {
                    CustomerListInfoLabel.Text = "No customers found";
                }

                CustomerDiv.Visible = true;
                CustomerGrid.DataSource = list.Select(x =>
                {
                    return new
                    {
                        x.ID,
                        x.Username,
                        x.Password,
                        x.Email,
                        x.Gender,
                    };
                });
                CustomerGrid.DataBind();
            }

            if (user.Role.Name == RoleRepository.AdminName)
            {
                var list = UserRepository.GetAllStaffs();
                if (list.Count == 0)
                {
                    StaffListInfoLabel.Text = "No staffs found";
                }

                StaffDiv.Visible = true;
                StaffGrid.DataSource = list.Select(x =>
                {
                    return new
                    {
                        x.ID,
                        x.Username,
                        x.Password,
                        x.Email,
                        x.Gender,
                    };
                });
                StaffGrid.DataBind();
            }
        }
    }
}