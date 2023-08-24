using Raamen.Controller;
using Raamen.Repository;
using System;
using System.Drawing;
using System.Web.UI;

namespace Raamen.View
{
    public partial class InsertRamenPage : Page
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

            if (MeatRadioButton.Items.Count == 0)
            {
                var meats = MeatRepository.GetMeats();
                foreach (var meat in meats)
                {
                    MeatRadioButton.Items.Add(meat.Name);
                }
            }
        }

        protected void OnInsertButtonClicked(object sender, EventArgs e)
        {
            var ramenName = RamenNameTextBox.Text;
            var meat = MeatRadioButton.SelectedValue;
            var broth = BrothTextbox.Text;
            var priceString = PriceTextbox.Text;

            ResultLabel.Text = RamenController.ValidateRamen(ramenName, meat, broth, priceString);
            ResultLabel.ForeColor = Color.Red;

            if (ResultLabel.Text == "Success!")
            {
                RamenRepository.InsertRamen(ramenName, meat, broth, int.Parse(priceString));

                ResultLabel.Text = "Ramen Inserted!";
                ResultLabel.ForeColor = Color.Green;
            }
        }

        protected void OnBackButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamenPage.aspx");
        }
    }
}