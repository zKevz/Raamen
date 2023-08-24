using Raamen.Controller;
using Raamen.Model;
using Raamen.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Raamen.View
{
    public partial class ManageRamenPage : Page
    {
        private static List<Ramen> m_Ramens;

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

            RefreshRamenGrid();
        }

        private void RefreshRamenGrid()
        {
            m_Ramens = RamenRepository.GetAllRamens();
            ManageRamenGridView.DataSource = m_Ramens.Select(x =>
            {
                return new
                {
                    RamenName = x.Name,
                    Meat = x.Meat.Name,
                    Price = x.Price.ToString("n"),
                    x.Broth,
                };
            });
            ManageRamenGridView.DataBind();
        }

        protected void OnManageRamenGridViewRowCommand(object sender, GridViewCommandEventArgs e)
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

                Response.Redirect($"UpdateRamenPage.aspx?ID={m_Ramens[index].ID}");
            }
            else if (e.CommandName == "Delete")
            {
                if (!int.TryParse((string)e.CommandArgument, out int index))
                {
                    return;
                }

                if (index < 0 || index >= m_Ramens.Count)
                {
                    return;
                }

                RamenRepository.DeleteRamen(m_Ramens[index]);

                m_Ramens.RemoveAt(index);
                RefreshRamenGrid();
            }
        }

        protected void OnInsertRamenButtonClicked(object sender, EventArgs e)
        {
            Response.Redirect("InsertRamenPage.aspx");
        }

        protected void ManageRamenGridView_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }
    }
}