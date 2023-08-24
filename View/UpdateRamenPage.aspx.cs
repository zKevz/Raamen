using Raamen.Controller;
using Raamen.Repository;
using System;
using System.Drawing;
using System.Web.UI;

namespace Raamen.View
{
    public partial class UpdateRamenPage : Page
    {
        private int RamenID;

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (user.Role.Name == RoleRepository.CustomerName)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (Request.QueryString["ID"] is null)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!int.TryParse(Request.QueryString["ID"], out RamenID))
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            if (!RamenRepository.IsRamenExistByID(RamenID))
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

            if (RamenNameTextBox.Text.Length == 0)
            {
                var ramen = RamenRepository.GetRamenByID(RamenID);

                BrothTextbox.Text = ramen.Broth;
                PriceTextbox.Text = ramen.Price.ToString();
                RamenNameTextBox.Text = ramen.Name;
                MeatRadioButton.SelectedValue = ramen.Meat.Name;
            }

            TitleLabel.Text = $"Update Ramen #{RamenID}";
        }

        protected void OnUpdateButtonClicked(object sender, EventArgs e)
        {
            var ramen = RamenRepository.GetRamenByID(RamenID);
            var ramenName = RamenNameTextBox.Text;
            var meat = MeatRadioButton.SelectedValue;
            var broth = BrothTextbox.Text;
            var priceString = PriceTextbox.Text;

            ResultLabel.Text = RamenController.ValidateRamenUpdate(ramenName, ramen.Name, meat, broth, priceString);
            ResultLabel.ForeColor = Color.Red;

            if (ResultLabel.Text == "Success!")
            {
                RamenRepository.UpdateRamen(RamenID, ramenName, meat, broth, int.Parse(priceString));

                ResultLabel.Text = "Ramen Updated!";
                ResultLabel.ForeColor = Color.Green;
            }
        }

        protected void OnBackButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("ManageRamenPage.aspx");
        }
    }
}