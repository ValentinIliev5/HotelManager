using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.Admin
{
    public partial class EditUser : System.Web.UI.Page
    {
        //Username/Email/First Name/Middle Name/Last Name/EGN/Phone/IsAdmin
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                List<string> properties = new List<string>();
                if (DBManager.FindUser(RouteData.Values["UserID"].ToString(), out properties))
                {
                    Username.Text = properties[0];
                    Email.Text = properties[1];
                    FirstName.Text = properties[2];
                    MiddleName.Text = properties[3];
                    LastName.Text = properties[4];
                    EGN.Text = properties[5];
                    Phone.Text = properties[6];
                    AdminCheckBox.Checked = properties[7] == "1";

                }
                else
                {
                    Response.Write("<script>alert('Error in database.')</script>");
                }
            }
        }

        protected void EditButton_Click(object sender, EventArgs e)
        {
            if(DBManager.EditUser(RouteData.Values["UserID"].ToString(),Username.Text,Email.Text,FirstName.Text,MiddleName.Text,LastName.Text,EGN.Text,Phone.Text,AdminCheckBox.Checked))
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