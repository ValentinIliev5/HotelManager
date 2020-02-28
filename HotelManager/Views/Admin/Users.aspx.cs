using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.Admin
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                BindListView();
            }

        }

        private void BindListView()
        {
            DataTable dt = new DataTable();
            if (DBManager.ListUsers(out dt))
            {
                string test = dt.Rows[0].ToString();
                UserList.DataSource = dt;
                UserList.DataBind();
            }
            else
            {
                Response.Write("<script>alert('Error in database.')</script>");
            }
        }

        protected void FireCommandAction_Command(object sender, CommandEventArgs e)
        {
            if(e.CommandArgument == null)
            {
                Response.Write("<script>alert('Error in database.')</script>");
            }
            else
            {
                if(DBManager.FireUser(e.CommandArgument.ToString()))
                {
                    BindListView();
                }
                else
                {
                    Response.Write("<script>alert('Error in database.')</script>");
                }
            }
        }
    }
}