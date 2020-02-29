using HotelManager.DBMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerReservationsPt3.Models
{
    public class ListRoom
    {
        public string ID { get; set; }

        public string Capacity { get; set; }

        public string Type { get; set; }

        public string AdultPrice { get; set; }

        public string KidPrice { get; set; }

        public string Number { get; set; }

        public static IEnumerable<ListRoom> GetRooms(string ColumnName)
        {
            List<ListRoom> rooms = new List<ListRoom>();
            if (DBManager.ListRooms(ColumnName, out rooms))
            {
                return rooms;
            }
            else
            {
                return new List<ListRoom>();
            }
        }
    }
}