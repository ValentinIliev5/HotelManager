using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.Admin
{
    public partial class AddRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void AddRoomButton_Click(object sender, EventArgs e)
        {
            if(DBManager.AddRoom(Capacity.Text,Type.Text,AdultPrice.Text,KidPrice.Text,Number.Text))
            {
                Response.Write("<script>alert('Room has been created.')</script>");
            }
            else
            {
                Response.Write("<script>alert('Room has not been created.')</script>");
            }
        }
    }
}