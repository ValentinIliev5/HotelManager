using HotelManager.DBMethods;
using HotelManagerReservationsPt3.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.Admin
{
    public partial class Clients : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClientDataPager.PageSize = Convert.ToInt32(PageDropDown.SelectedValue);
                ClientList.DataBind();
            }

        }


        protected void DeleteCommandAction_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandArgument == null)
            {
                Response.Write("<script>alert('Error in database.')</script>");
            }
            else
            {
                if (DBManager.DeleteClient(e.CommandArgument.ToString()))
                {
                    ClientList.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error in database.')</script>");
                }
            }
        }

        protected void PageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            ClientDataPager.PageSize = Convert.ToInt32(PageDropDown.SelectedValue);
            ClientList.DataBind();
        }
    }
}