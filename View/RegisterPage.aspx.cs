using Raamen.Controller;
using Raamen.Repository;
using System;
using System.Drawing;
using System.Web.UI;

namespace Raamen.View
{
    public partial class RegisterPage : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (UserController.CheckSessionOrCookie(Session, Request) != null)
            {
                Response.Redirect("HomePage.aspx");
            }
        }

        protected void OnRegisterButtonClicked(object sender, EventArgs e)
        {
            var username = UsernameTextbox.Text;
            var password = PasswordTextbox.Text;
            var confirmationPassword = ConfirmationPasswordTextbox.Text;
            var email = EmailTextbox.Text;
            var gender = GenderRadioButtonList.SelectedValue;

            ResultLabel.Text = UserController.ValidateRegister(username, password, confirmationPassword, email, gender);
            ResultLabel.ForeColor = Color.Red;

            if (ResultLabel.Text == "Success!")
            {
                UserRepository.InsertUser(username, password, email, gender);
                Response.Redirect("LoginPage.aspx");
            }
        }
    }
}