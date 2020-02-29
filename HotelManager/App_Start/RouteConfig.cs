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
                "Register",
                "~/Account/Register.aspx"
            );

            routes.MapPageRoute(
                "Login",
                "Login",
                "~/Account/Login.aspx"
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
        }
    }
}
