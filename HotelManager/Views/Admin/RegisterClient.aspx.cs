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
        public static bool AddClient(string FirstName, string MiddleName, string LastName, string Phone,bool isAdult)
        {
            try
            {
                Client client = new Client();
                client.FirstName = FirstName;
                client.MiddleName = MiddleName;
                client.LastName = LastName;
                client.Phone = Phone;
                client.IsAdult = isAdult;

                using (HotelDBContext context = new HotelDBContext())
                {
                    context.Clients.Add(client);

                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                string a = ex.Message;
                return false;
            }

            return true;
        }

        protected void AddClient_Click(object sender, EventArgs e)
        {
            
            if (AddClient(FirstName.Text,MiddleName.Text,LastName.Text,Phone.Text,IsAdult.Checked))
            {
                Response.Write("<script>alert('Client has been created.')</script>");
            }
            else Response.Write("<script>alert('Client has not been created.')</script>");
        }
    }
}