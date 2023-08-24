using Raamen.Controller;
using Raamen.Repository;
using System;
using System.Drawing;
using System.Web;
using System.Web.UI;

namespace Raamen.View
{
    public partial class LoginPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!(UserController.CheckSessionOrCookie(Session, Request) is null))
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var username = UsernameTextbox.Text.Trim();
            var password = PasswordTextbox.Text;

            ResultLabel.Text = UserController.ValidateLogin(username, password);
            ResultLabel.ForeColor = Color.Red;

            if (ResultLabel.Text == "Success!")
            {
                Session["User"] = UserRepository.GetUserByName(username);

                if (RememberMeCheckbox.Checked)
                {
                    var expiresDate = DateTime.Now.AddDays(3);
                    var cookieUsername = new HttpCookie("Cookie_Username")
                    {
                        Value = username,
                        Expires = expiresDate
                    };

                    var cookiePassword = new HttpCookie("Cookie_Password")
                    {
                        Value = password,
                        Expires = expiresDate
                    };

                    Response.Cookies.Add(cookieUsername);
                    Response.Cookies.Add(cookiePassword);
                }

                Response.Redirect("HomePage.aspx");
            }
        }
    }
}