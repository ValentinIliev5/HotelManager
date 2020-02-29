using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.Admin
{
    public partial class EditRoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> properties = new List<string>();
                if (DBManager.FindRoom(RouteData.Values["ID"].ToString(), out properties))
                {
                    Capacity.Text = properties[0];
                    Type.Text = properties[1];
                    AdultPrice.Text = properties[2];
                    KidPrice.Text = properties[3];
                    Number.Text = properties[4];
                }
                else
                {
                    Response.Write("<script>alert('Error in database.')</script>");
                }
            }
        }

        protected void EditRoomButton_Click(object sender, EventArgs e)
        {
            if (DBManager.EditRoom(RouteData.Values["ID"].ToString(), Capacity.Text, Type.Text, AdultPrice.Text, KidPrice.Text, Number.Text))
            {
                Response.Write("<script>alert('Success')</script>");
            }
            else
            {
                Response.Write("<script>alert('Error in database.')</script>");
            }
        }
    }
}