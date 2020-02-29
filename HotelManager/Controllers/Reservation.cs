using HotelManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelManagerReservationsPt3.Controllers
{
    public class Reservation
    {
        //public static bool GetEmptyRooms(DateTime dateTime, out List<Room> rooms)
        //{
        //    try
        //    {
        //        rooms = new List<Room>();

        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            rooms.AddRange(context.Rooms);

        //            foreach (Reservation item in context.Reservations
        //                .Where(a => a.ArrivalDate <= dateTime
        //                && a.DeparatureDate > dateTime))
        //            {
        //                rooms.Remove(item.Room);
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}



        public static List<Room> GetRooms(Predicate<Room> action)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    return context.Rooms.Where(a => action(a)).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Room>();
            }
        }


        #region Confirmation

        //public static bool IsRoomEmpty(DateTime dateTime, int roomId)
        //{
        //    try
        //    {
        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            IQueryable<Reservation> reservations = context.Reservations
        //            .Where(a => a.ArrivalDate <= dateTime && a.DeparatureDate > dateTime);

        //            if (reservations.Any())
        //            {
        //                return reservations.Any(a => a.ID == roomId) == false;
        //            }

        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        #endregion

        #region GetDateWhenRoomIsFree

        //public static DateTime GetDateWhenRoomIsFree(int roomId)
        //{
        //    using (HotelDBContext context = new HotelDBContext())
        //    {
        //        IQueryable<Reservation> reservations =
        //            context.Reservations.Where(a => a.Room.ID == roomId);

        //        if (reservations.Any())
        //        {
        //            return 
        //        }
        //    }
        //}

        #endregion

        //public static bool IsThereEmptyRoom(DateTime dateTime)
        //{
        //    try
        //    {
        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            List<Room> rooms = new List<Room>();

        //            foreach (Reservation item in context.Reservations)
        //            {
        //                rooms.Remove(item.Room);
        //            }

        //            return rooms.Any();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        //public static bool GetEmptyRooms(DateTime dateTime, out List<Room> rooms)
        //{
        //    try
        //    {
        //        rooms = new List<Room>();

        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            rooms.AddRange(context.Rooms);

        //            foreach (Reservation item in context.Reservations
        //                .Where(a => a.ArrivalDate <= dateTime
        //                && a.DeparatureDate > dateTime))
        //            {
        //                rooms.Remove(item.Room);
        //            }
        //        }

        //        return true;
        //    }
        //    catch (Exception)
        //    {
        //        rooms = new List<Room>();

        //        return false;
        //    }
        //}

        //public static bool IsRoomEmpty(DateTime dateTime, int roomId)
        //{
        //    try
        //    {
        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            IQueryable<Reservation> reservations = context.Reservations
        //            .Where(a => a.ArrivalDate <= dateTime && a.DeparatureDate > dateTime);

        //            if (reservations.Any())
        //            {
        //                return reservations.Any(a => a.ID == roomId) == false;
        //            }

        //            return false;
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

        public static List<Room>ListRooms(Predicate<Room> action)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    return context.Rooms.Where(a => action(a)).ToList();
                }
            }
            catch (Exception)
            {
                return new List<Room>();
            }
        }

        //public static DateTime GetDateWhenRoomIsFree(TimeSpan timeSpan, int roomId)
        //{
        //    try
        //    {
        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            IQueryable<Reservation> reservations =
        //                context.Reservations.Where(a => a.Room.ID == roomId).OrderBy(a => a.ArrivalDate);

        //            if (reservations.Any())
        //            {
        //                if (reservations.ElementAt(0).ArrivalDate - DateTime.Now >= timeSpan)
        //                {
        //                    return DateTime.Now;
        //                }

        //                for (int i = 0; i < reservations.Count() - 1; i++)
        //                {
        //                    if (reservations.ElementAt(i + 1).ArrivalDate
        //                        - reservations.ElementAt(i).DeparatureDate >= timeSpan)
        //                    {
        //                        return reservations.ElementAt(i).DeparatureDate;
        //                    }
        //                }
        //            }
        //            else
        //            {
        //                return DateTime.Now;
        //            }

        //            return reservations.ElementAt(reservations.Count() - 1).DeparatureDate;
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //}

        //public static bool IsRoomEmpty(TimeSpan timeSpan, DateTime dateTime, int roomId)
        //{
        //    try
        //    {
        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            IQueryable<Reservation> reservations =
        //                context.Reservations.Where(a => a.Room.ID == roomId);

        //            if (reservations.Any())
        //            {
        //                reservations = reservations.OrderBy(a => a.ArrivalDate);

        //                if (reservations.ElementAt(0).ArrivalDate > dateTime)
        //                {
        //                    return reservations.ElementAt(0).ArrivalDate - dateTime >= timeSpan;
        //                }

        //                for (int i = 0; i < reservations.Count() - 1; i++)
        //                {
        //                    if (reservations.ElementAt(i).ArrivalDate <= dateTime)
        //                    {
        //                        if (reservations.ElementAt(i).DeparatureDate > dateTime)
        //                        {
        //                            return false;
        //                        }
        //                        else
        //                        {
        //                            if (reservations.ElementAt(i + 1).ArrivalDate > dateTime)
        //                            {
        //                                return reservations.ElementAt(i + 1).ArrivalDate - reservations.ElementAt(i).DeparatureDate >= timeSpan;
        //                            }
        //                            else
        //                            {
        //                                continue;
        //                            }
        //                        }
        //                    }
        //                    else
        //                    {
        //                        return dateTime - reservations.ElementAt(i - 1).DeparatureDate >= timeSpan;
        //                    }

        //                    //if (reservations.ElementAt(i + 1).ArrivalDate > dateTime)
        //                    //{
        //                    //    if (reservations.ElementAt(i).DeparatureDate <= dateTime)
        //                    //    {
        //                    //        if (reservations.ElementAt(i + 1).ArrivalDate - reservations.ElementAt(i).DeparatureDate >= timeSpan)
        //                    //        {
        //                    //            return true;
        //                    //        }
        //                    //        else
        //                    //        {
        //                    //            return false;
        //                    //        }
        //                    //    }
        //                    //    else
        //                    //    {
        //                    //        return 
        //                    //    }
        //                    //}
        //                }
        //            }
        //            else
        //            {
        //                return true;
        //            }

        //            if (reservations.All(a => a.DeparatureDate <= dateTime))
        //            {
        //                return true;
        //            }
        //            else
        //            {
        //                return false;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;

        //        throw ex;
        //    }
        //}

        public static bool GetEmptyRooms(TimeSpan timeSpan, DateTime dateTime, int roomId, out List<Room> rooms)
        {
            try
            {
                rooms = new List<Room>();

                using (HotelDBContext context = new HotelDBContext())
                {
                    foreach (Room item in context.Rooms)
                    {
                        rooms.Add(item);
                    }
                }

                return true;
            }
            catch (Exception)
            {
                rooms = new List<Room>();

                return false;
            }
        }

        //public static bool IsThereEmptyRoom(DateTime dateTime)
        //{
        //    try
        //    {
        //        using (HotelDBContext context = new HotelDBContext())
        //        {
        //            List<Room> rooms = new List<Room>();

        //            foreach (Reservation item in context.Reservations)
        //            {
        //                rooms.Remove(item.Room);
        //            }

        //            return rooms.Any();
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        return false;
        //    }
        //}

    }
}