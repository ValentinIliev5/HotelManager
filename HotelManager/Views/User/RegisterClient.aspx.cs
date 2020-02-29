using HotelManager.DBMethods;
using HotelManager.Models;
using HotelManagerReservationsPt3.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views
{
    public partial class RegisterClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        

        protected void AddClient_Click(object sender, EventArgs e)
        {
            
            if (DBManager.AddClient(FirstName.Text,MiddleName.Text,LastName.Text,Phone.Text,IsAdult.Checked))
            {
                Response.Write("<script>alert('Client has been created.')</script>");
            }
            else Response.Write("<script>alert('Client has not been created.')</script>");
        }
    }
}