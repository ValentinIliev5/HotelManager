using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.Admin
{
    public partial class Rooms : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                RoomDataPager.PageSize = Convert.ToInt32(PageDropDown.SelectedValue);
                RoomList.DataBind();
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
                if (DBManager.DeleteRoom(e.CommandArgument.ToString()))
                {
                    RoomList.DataBind();
                }
                else
                {
                    Response.Write("<script>alert('Error in database.')</script>");
                }
            }
        }

        protected void PageDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            RoomDataPager.PageSize = Convert.ToInt32(PageDropDown.SelectedValue);
            RoomList.DataBind();
        }
    }
}