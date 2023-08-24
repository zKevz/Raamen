using Raamen.Controller;
using Raamen.Factory;
using Raamen.Model;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class OrderRamenPage : Page
    {
        private static readonly List<Ramen> m_Ramens = RamenRepository.GetAllRamens();
        public static readonly List<RamenCart> m_Cart = new List<RamenCart>();

        protected void Page_Load(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);
            if (user is null)
            {
                Response.Redirect("LoginPage.aspx");
                return;
            }

            if (user.Role.Name != RoleRepository.CustomerName)
            {
                Response.Redirect("HomePage.aspx");
                return;
            }

            RefreshRamenGrid();
            RefreshCartGrid();
        }

        private void RefreshRamenGrid()
        {
            RamenGridView.AutoGenerateColumns = false;
            RamenGridView.DataSource = m_Ramens.Select(x =>
            {
                return new
                {
                    RamenName = x.Name,
                    Meat = x.Meat.Name,
                    Price = x.Price.ToString("n"),
                    x.Broth,
                };
            });
            RamenGridView.DataBind();
        }

        private void RefreshCartGrid()
        {
            CartGridView.AutoGenerateColumns = false;
            CartGridView.DataSource = m_Cart.Select(x =>
            {
                return new
                {
                    RamenName = x.Ramen.Name,
                    Meat = x.Ramen.Meat.Name,
                    Price = x.Ramen.Price.ToString("n"),
                    x.Ramen.Broth,
                    x.Quantity
                };
            });

            CartLabel.ForeColor = Color.Green;
            CartGridView.DataBind();

            if (m_Cart.Count == 0)
            {
                CartLabel.Text = "Cart is empty.";
                CartLabel.Visible = true;
                TotalLabel.Visible = false;
                BuyCartButton.Visible = false;
                ClearCartButton.Visible = false;
            }
            else
            {
                CartLabel.Visible = false;
                TotalLabel.Visible = true;
                BuyCartButton.Visible = true;
                ClearCartButton.Visible = true;

                int total = 0;
                foreach (var cart in m_Cart)
                {
                    total += cart.Ramen.Price * cart.Quantity;
                }

                TotalLabel.Text = $"Total: Rp. {total:n}";
            }
        }

        protected void OnClearCartButtonClicked(object sender, EventArgs e)
        {
            m_Cart.Clear();
            RefreshCartGrid();
        }

        protected void OnBuyCartButtonClicked(object sender, EventArgs e)
        {
            var user = UserController.CheckSessionOrCookie(Session, Request);

            if (Application["UnhandledTransactions"] is null)
            {
                Application["UnhandledTransactions"] = new List<UnhandledTransaction>();
            }

            var carts = (List<UnhandledTransaction>)Application["UnhandledTransactions"];
            carts.Add(new UnhandledTransaction()
            {
                Date = DateTime.Now,
                Carts = m_Cart.ToList(),
                Customer = user
            });

            m_Cart.Clear();
            CartLabel.Text = "Transactions added.";
            RefreshCartGrid();
        }

        protected void OnRamenGridViewRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                if (!int.TryParse((string)e.CommandArgument, out int index))
                {
                    return;
                }

                if (index < 0 || index >= m_Ramens.Count)
                {
                    return;
                }

                var cart = m_Cart.FirstOrDefault(x => x.Ramen == m_Ramens[index]);
                if (!(cart is null))
                {
                    cart.Quantity += 1;
                }
                else
                {
                    m_Cart.Add(new RamenCart()
                    {
                        Ramen = m_Ramens[index],
                        Quantity = 1
                    });
                }

                RefreshCartGrid();
            }
        }

        protected void OnCartGridViewRowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Remove")
            {
                if (!int.TryParse((string)e.CommandArgument, out int index))
                {
                    return;
                }

                if (index < 0 || index >= m_Cart.Count)
                {
                    return;
                }

                if (m_Cart[index].Quantity == 1)
                {
                    m_Cart.RemoveAt(index);
                }
                else
                {
                    m_Cart[index].Quantity -= 1;
                }

                RefreshCartGrid();
            }
        }
    }
}