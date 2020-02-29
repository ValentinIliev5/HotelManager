using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HotelManagerReservationsPt3.Models
{
    public class ListClient
    {
        public int ID { get; set; }

        public string FullName { get; set; }

        public string Phone { get; set; }

        public string IsAdult { get; set; }

        public static IEnumerable<ListClient> GetClients(string ColumnName)
        {
            List<ListClient> clients = new List<ListClient>();
            if (DBManager.ListClients(ColumnName, out clients))
            {
                return clients;
            }
            else
            {
                return new List<ListClient>();
            }
        }

    }
}