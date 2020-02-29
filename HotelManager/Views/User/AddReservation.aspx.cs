using HotelManager.DBMethods;
using HotelManager.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HotelManagerReservationsPt3.Views.User
{
    public partial class AddReservation : System.Web.UI.Page
    {
        private List<Client> listClients = new List<Client>();
        private List<Room> listRooms = new List<Room>();
        double price = 0.00;
        protected void Page_Load(object sender, EventArgs e)
        {
            ClientsList.SelectionMode = ListSelectionMode.Multiple;

            if (!IsPostBack)
            {
                DBManager.savedClients = null;
                FillRoomsInListBox();
                FillClientsInListBox();
            }

        }
        private void FillRoomsInListBox()
        {
            listRooms = null;
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    listRooms = context.Rooms.ToList();
                }

                foreach (var item in listRooms)
                {
                    RoomList.Items.Add(item.Number);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void FillClientsInListBox()
        {
            listClients = null;
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    listClients = context.Clients.ToList();
                }
                DBManager.savedClients = listClients;
                foreach (var item in listClients)
                {
                    string fullClientName = item.FirstName + " " + item.MiddleName + " " + item.LastName;
                    ClientsList.Items.Add(fullClientName);
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        protected void AddReservation_Click(object sender, EventArgs e)
        {
            listClients = DBManager.savedClients;
            string userId = Context.GetOwinContext().Authentication.User.Identity.GetUserId();
            int userDBId = DBManager.FindAndReturnUserDBID(userId);

            string roomNumber = RoomList.SelectedItem.ToString();
            var currentRoom = new Room();
            currentRoom = DBManager.FindRoom(roomNumber);

            var selectedClients = new List<Client>();
            for (int i = 0; i < ClientsList.Items.Count; i++)
            {
                if (i == 0 || i == 2 || i == 4)
                {
                    ClientsList.Items[i].Selected = true;
                    selectedClients.Add(listClients[i]);
                }
            }
            // CALCULATED PRICE !!!!!!!!!!!!!!!!!!!!
            CalculatedPrice(currentRoom.AdultPrice, currentRoom.KidPrice);
          
            DateTime arrival = ArrivalDate.SelectedDate;
            DateTime deparature = DeparatureDate.SelectedDate;
            bool hasbreackfast = HasBreakfast.Checked;
            bool isallinclusive = IsAllInclusive.Checked;

            if (DBManager.AddReservation(currentRoom.ID, userDBId, selectedClients, arrival, deparature,
             hasbreackfast, isallinclusive, price))
            {
                Response.Write("<script>alert('Reservation has been created.')</script>");
            }
            else Response.Write("<script>alert('Reservation has not been created.')</script>");
            
        }
        private void CalculatedPrice(double AdultPrice, double KidPrice)
        {
            
            foreach (var client in listClients)
            {
                if (client.IsAdult)
                {
                    price += AdultPrice;
                }
                else
                {
                    price += KidPrice;
                }

            }
        }
    }
}