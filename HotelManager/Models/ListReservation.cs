using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerReservationsPt3.Models
{
    public class ListReservation
    {
        public string ID { get; set; }

        public string RoomNumber { get; set; }

        public string UserUsername { get; set; }

        public string Clients { get; set; }

        public string ArrivalDate { get; set; }

        public string DeparatureDate { get; set; }

        public string HasBreakfast { get; set; }

        public string IsAllInclusive { get; set; }

        public string Price { get; set; }

        public static IEnumerable<ListReservation> GetReservations(string ColumnName)
        {
            List<ListReservation> reservations = new List<ListReservation>();
            if (DBManager.ListReservations(ColumnName, out reservations))
            {
                return reservations;
            }
            else
            {
                return new List<ListReservation>();
            }
        }
    }
}