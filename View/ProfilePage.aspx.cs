using Raamen.Controller;
using Raamen.Handler;
using Raamen.Repository;
using System;
using System.Drawing;
using System.Web.UI;

namespace Raamen.View
{
    public partial class ProfilePage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (EmailTextbox.Text.Length == 0)
            {
                EmailTextbox.Text = user.Email;
                UsernameTextbox.Text = user.Username;
                GenderRadioButtonList.SelectedValue = user.Gender;
            }
        }

        protected void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            var username = UsernameTextbox.Text;
            var password = PasswordTextbox.Text;
            var email = EmailTextbox.Text;
            var gender = GenderRadioButtonList.SelectedValue;

            ResultLabel.Text = UserController.ValidateUpdate(username, user.Username, password, user.Password, email, gender);
            ResultLabel.ForeColor = Color.Red;

            if (ResultLabel.Text == "Success!")
            {
                UserHandler.UpdateUser(user, email, gender, username);

                if (!(Response.Cookies["Cookie_Username"] is null))
                {
                    Response.Cookies["Cookie_Username"].Value = username;
                }


                ResultLabel.Text = "User Updated!";
                ResultLabel.ForeColor = Color.Green;
            }
        }
    }
}