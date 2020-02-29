using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.AspNet.FriendlyUrls;

namespace HotelManagerReservationsPt3
{
    public static class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.MapPageRoute(
                "Register",
                "Account/Register",
                "~/Account/Register.aspx"
            );

            routes.MapPageRoute(
                "Login",
                "Account/Login",
                "~/Account/Login.aspx"
            );

            routes.MapPageRoute(
                "About",
                "About",
                "~/About.aspx"
            );

            routes.MapPageRoute(
                "Users",
                "Admin/Users",
                "~/Views/Admin/Users.aspx"
            );

            routes.MapPageRoute(
                "Edit-User",
                "Admin/Users/EditUser/{UserID}",
                "~/Views/Admin/EditUser.aspx"
            );

            routes.MapPageRoute(
                "Clients",
                "User/Clients",
                "~/Views/User/Clients.aspx"
            );

            routes.MapPageRoute(
                "Add-Client",
                "User/Clients/AddClient",
                "~/Views/User/RegisterClient.aspx"
            );

            routes.MapPageRoute(
                "Edit-Client",
                "User/Clients/EditClient/{ID}",
                "~/Views/User/EditClient.aspx"
            );

            routes.MapPageRoute(
                "Add-Room",
                "Admin/Rooms/AddRoom",
                "~/Views/Admin/AddRoom.aspx"
            );

            routes.MapPageRoute(
                "Rooms",
                "Admin/Rooms",
                "~/Views/Admin/Rooms.aspx"
            );

            routes.MapPageRoute(
                "Edit-Room",
                "Admin/Rooms/EditRoom/{ID}",
                "~/Views/Admin/EditRoom.aspx"
            );

           routes.MapPageRoute(
                "Reservations",
                "User/Reservations",
                "~/Views/User/Reservations.aspx"
            );

            routes.MapPageRoute(
                "Add-Reservation",
                "User/Reservations/AddReservation",
                "~/Views/User/AddReservation.aspx"
            );

            routes.MapPageRoute(
                "Edit-Reservation",
                "User/Reservations/EditReservation/{ID}",
                "~/Views/User/EditReservation.aspx"
            );
        }
    }
}
