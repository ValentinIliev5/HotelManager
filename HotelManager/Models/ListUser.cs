using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerReservationsPt3.Models
{
    public class ListUser
    {
        public string UserID { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

        public string EGN { get; set; }

        public string Phone { get; set; }

        public string HiredDate { get; set; }

        public string IsActive { get; set; }

        public string FiredDate { get; set; }

        public static IEnumerable<ListUser> GetUsers(string ColumnName)
        {
            List<ListUser> users = new List<ListUser>();
            if (DBManager.ListUsers(ColumnName, out users))
            {
                return users;
            }
            else
            {
                return new List<ListUser>();
            }
        }

    }
}