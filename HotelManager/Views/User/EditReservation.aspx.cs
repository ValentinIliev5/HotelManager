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
    public partial class EditReservation : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    using (HotelDBContext context = new HotelDBContext())
                    {
                        context.Rooms.ToList().ForEach(w => RoomList.Items.Add(w.Number));
                        context.Clients.ToList().ForEach(w => ClientsList.Items.Add(w.FirstName + " " + w.MiddleName + " " + w.LastName));
                    }
                }
                catch
                {
                    Response.Write("<script>alert('Error in database.')</script>");
                }
            }
        }

        protected void EditReservationButton_Click(object sender, EventArgs e)
        {

            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    if (context.Rooms.First(w => w.Number == RoomList.SelectedValue.ToString()).Capacity < ClientsList.GetSelectedIndices().Count())
                    {
                        Response.Write("<script>alert('Client count must be lower than room capacity.')</script>");
                        return;
                    }
                    if (ArrivalDate.SelectedDate > DeparatureDate.SelectedDate)
                    {
                        Response.Write("<script>alert('Arrival date must be sooner that the departure date.')</script>");
                        return;
                    }

                    double price = 0;

                    int ReservationID = int.Parse(RouteData.Values["ID"].ToString());
                    Reservation reservation = context.Reservations.First(w => w.ID == ReservationID);
                    Room room = context.Rooms.First(w => w.Number == RoomList.SelectedValue.ToString());
                    List<Client> clients = new List<Client>();

                    reservation.RoomID = room.ID;
                    string currentUserID = Context.GetOwinContext().Authentication.User.Identity.GetUserId();
                    reservation.UserID = context.Users.First(w => w.UserID == currentUserID).ID;

                    foreach (ListItem item in ClientsList.Items)
                    {
                        if (item.Selected)
                        {
                            string itemString = item.Value.ToString();
                            clients.Add(context.Clients.First(w => w.FirstName + " " + w.MiddleName + " " + w.LastName == itemString));
                        }
                    }

                    reservation.Clients = clients;

                    clients.ForEach(w =>
                    {
                        if (w.IsAdult)
                        {
                            price += room.AdultPrice * ((DeparatureDate.SelectedDate - ArrivalDate.SelectedDate).TotalDays);
                        }
                        else
                        {
                            price += room.KidPrice * ((DeparatureDate.SelectedDate - ArrivalDate.SelectedDate).TotalDays);
                        }
                    });

                    reservation.ArrivalDate = ArrivalDate.SelectedDate;
                    reservation.DeparatureDate = DeparatureDate.SelectedDate;
                    reservation.HasBreakfast = HasBreakfast.Checked;
                    reservation.IsAllInclusive = IsAllInclusive.Checked;
                    reservation.Price = price;

                    context.SaveChanges();
                    Response.Write("<script>alert('Success.')</script>");
                }
            }
            catch (Exception ex)
            {
                string message = ex.Message;
                Response.Write("<script>alert('Error in database.')</script>");
            }
        }
    }
}