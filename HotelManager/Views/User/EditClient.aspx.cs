using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.User
{
    public partial class EditClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> properties = new List<string>();
                if (DBManager.FindClient(RouteData.Values["ID"].ToString(), out properties))
                {

                    FirstName.Text = properties[0];
                    MiddleName.Text = properties[1];
                    LastName.Text = properties[2];
                    Phone.Text = properties[3];
                    IsAdult.Checked = properties[4] == "1";

                }
                else
                {
                    Response.Write("<script>alert('Error in database.')</script>");
                }
            }
        }

        protected void EditCurrentClient_Click(object sender, EventArgs e)
        {
            if (DBManager.EditClient(RouteData.Values["ID"].ToString(), FirstName.Text, MiddleName.Text, LastName.Text, Phone.Text, IsAdult.Checked))
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