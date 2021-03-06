﻿using HotelManager.Models;
using HotelManagerReservationsPt3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Dynamic;
using System.Threading.Tasks;

namespace HotelManager.DBMethods
{
    public static class DBManager
    {

        public static List<Client> savedClients = new List<Client>();

        //User
        public static bool AddUser(string UserID, string FirstName, string MiddleName, string LastName, string EGN, string Phone)
        {
            try
            {
                User user = new User();
                user.UserID = UserID;
                user.FirstName = FirstName;
                user.MiddleName = MiddleName;
                user.LastName = LastName;
                user.EGN = EGN;
                user.Phone = Phone;
                user.IsActive = true;
                user.IsAdmin = false;
                user.HireDate = DateTime.Now;

                using (HotelDBContext context = new HotelDBContext())
                {
                    context.Users.Add(user);

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool FireUser(string UserID)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    context.Users.First(w => w.UserID == UserID).FiredDate = DateTime.Now;
                    context.Users.First(w => w.UserID == UserID).IsActive = false;
                    context.Users.First(w => w.UserID == UserID).IsAdmin = false;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool MakeUserAdmin(string UserID)
        {

            try
            {


                using (HotelDBContext context = new HotelDBContext())
                {
                    context.Users.FirstOrDefault(w => w.UserID == UserID).IsAdmin = true;

                    context.SaveChanges();
                }

                using (ApplicationDbContext apContext = new ApplicationDbContext())
                {
                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(apContext));
                    UserManager.AddToRole(UserID, "ADMIN");
                    apContext.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }


        public static bool ListUsers(out DataTable users)
        {
            try
            {
                List<User> dbUsers = new List<User>();
                List<ApplicationUser> appUsers = new List<ApplicationUser>();

                using (HotelDBContext context = new HotelDBContext())
                {
                    dbUsers = context.Users.ToList();
                }

                using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
                {
                    appUsers = applicationDbContext.Users.ToList();
                }

                DataTable dt = new DataTable();
                dt.Columns.Add("UserID");
                dt.Columns.Add("Username");
                dt.Columns.Add("Email");
                dt.Columns.Add("FullName");
                dt.Columns.Add("EGN");
                dt.Columns.Add("Phone");
                dt.Columns.Add("HiredDate");
                dt.Columns.Add("FiredDate");
                dt.Columns.Add("IsActive");

                List<DataRow> dataRows = new List<DataRow>();

                foreach (var user in dbUsers)
                {
                    DataRow row = dt.NewRow();

                    ApplicationUser appUser = appUsers.First(w => w.Id == user.UserID);

                    row["UserID"] = user.UserID;
                    row["Username"] = appUser.UserName;
                    row["Email"] = appUser.Email;
                    row["FullName"] = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                    row["EGN"] = user.EGN;
                    row["Phone"] = user.Phone;
                    row["HiredDate"] = user.HireDate.ToShortDateString();
                    if (user.FiredDate == null)
                    {
                        row["FiredDate"] = "-";
                    }
                    else
                    {
                        row["FiredDate"] = user.FiredDate.Value.ToShortDateString();
                    }
                    row["IsActive"] = user.IsActive ? "1" : "0";

                    dt.Rows.Add(row);
                }

                users = dt;

            }
            catch (Exception)
            {
                users = new DataTable();
                return false;
            }

            return true;
        }

        public static bool ListUsers(string ColumnName, out List<ListUser> users)
        {
            try
            {
                List<User> dbUsers = new List<User>();
                List<ApplicationUser> appUsers = new List<ApplicationUser>();
                users = new List<ListUser>();

                using (HotelDBContext context = new HotelDBContext())
                {
                    dbUsers = context.Users.ToList();
                }

                using (ApplicationDbContext applicationDbContext = new ApplicationDbContext())
                {
                    appUsers = applicationDbContext.Users.ToList();
                }

                foreach (var user in dbUsers)
                {
                    ApplicationUser appUser = appUsers.First(w => w.Id == user.UserID);

                    ListUser listUser = new ListUser();

                    listUser.UserID = user.UserID;
                    listUser.Username = appUser.UserName;
                    listUser.Email = appUser.Email;
                    listUser.FullName = user.FirstName + " " + user.MiddleName + " " + user.LastName;
                    listUser.EGN = user.EGN;
                    listUser.Phone = user.Phone;
                    listUser.HiredDate = user.HireDate.ToShortDateString();
                    if (user.FiredDate == null)
                    {
                        listUser.FiredDate = "-";
                    }
                    else
                    {
                        listUser.FiredDate = user.FiredDate.Value.ToShortDateString();
                    }
                    listUser.IsActive = user.IsActive ? "1" : "0";

                    users.Add(listUser);
                }

                if (ColumnName != "")
                {
                    users = users.OrderBy(ColumnName).ToList();
                }
            }
            catch (Exception)
            {
                users = new List<ListUser>();
                return false;
            }

            return true;
        }

        public static bool IsUserNotFiredOrDeleted(string UserID)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    if (context.Users.Count(w => w.UserID == UserID) == 0)
                    {
                        return false;
                    }
                    if (!context.Users.First(w => w.UserID == UserID).IsActive)
                    {
                        return false;
                    }
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        //Username/Email/First Name/Middle Name/Last Name/EGN/Phone/IsAdmin
        public static bool FindUser(string UserID, out List<string> properties)
        {

            try
            {
                properties = new List<string>();

                User user = new User();
                ApplicationUser appUser = new ApplicationUser();

                using (ApplicationDbContext appContext = new ApplicationDbContext())
                {
                    appUser = appContext.Users.First(w => w.Id == UserID);
                }

                using (HotelDBContext context = new HotelDBContext())
                {
                    user = context.Users.First(w => w.UserID == UserID);
                }

                properties.Add(appUser.UserName);
                properties.Add(appUser.Email);
                properties.Add(user.FirstName);
                properties.Add(user.MiddleName);
                properties.Add(user.LastName);
                properties.Add(user.EGN);
                properties.Add(user.Phone);
                properties.Add(user.IsAdmin ? "1" : "0");
            }
            catch (Exception)
            {
                properties = new List<string>();
                return false;
            }

            return true;
        }

        public static bool EditUser(string UserID, string Username, string Email, string FirstName, string MiddleName, string LastName, string EGN, string Phone, bool IsAdmin)
        {
            try
            {
                using (ApplicationDbContext appContext = new ApplicationDbContext())
                {
                    ApplicationUser appUser = new ApplicationUser();
                    appUser = appContext.Users.First(w => w.Id == UserID);

                    appUser.UserName = Username;
                    appUser.Email = Email;

                    var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(appContext));

                    if (IsAdmin)
                    {
                        UserManager.AddToRole(UserID, "ADMIN");
                    }
                    else
                    {
                        UserManager.RemoveFromRole(UserID, "ADMIN");
                    }

                    appContext.SaveChanges();
                }

                using (HotelDBContext context = new HotelDBContext())
                {
                    User user = new User();
                    user = context.Users.First(w => w.UserID == UserID);

                    user.FirstName = FirstName;
                    user.MiddleName = MiddleName;
                    user.LastName = LastName;
                    user.EGN = EGN;
                    user.Phone = Phone;
                    user.IsAdmin = IsAdmin;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        //Client

        public static bool AddClient(string FirstName, string MiddleName, string LastName, string Phone, bool isAdult)
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

        public static bool ListClients(string ColumnName, out List<ListClient> clients)
        {
            try
            {
                clients = new List<ListClient>();

                var dbClients = new List<Client>();

                using (HotelDBContext context = new HotelDBContext())
                {
                    dbClients = context.Clients.ToList();
                }

                foreach (var dbClient in dbClients)
                {
                    ListClient client = new ListClient();
                    client.ID = dbClient.ID;
                    client.FullName = dbClient.FirstName + " " + dbClient.MiddleName + " " + dbClient.LastName;
                    client.Phone = dbClient.Phone;
                    client.IsAdult = dbClient.IsAdult ? "1" : "0";

                    clients.Add(client);
                }

                if (ColumnName != "")
                {
                    clients = clients.OrderBy(ColumnName).ToList();
                }
            }
            catch (Exception)
            {
                clients = new List<ListClient>();
                return false;
            }

            return true;
        }

        public static bool DeleteClient(string ID)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    int ClientID = Convert.ToInt32(ID);
                    context.Clients.Remove(context.Clients.First(w => w.ID == ClientID));
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        public static bool FindClient(string ID, out List<string> properties)
        {

            try
            {
                properties = new List<string>();

                int ClientID = int.Parse(ID);
                Client client = new Client();

                using (HotelDBContext context = new HotelDBContext())
                {
                    client = context.Clients.First(w => w.ID == ClientID);
                }

                properties.Add(client.FirstName);
                properties.Add(client.MiddleName);
                properties.Add(client.LastName);
                properties.Add(client.Phone);
                properties.Add(client.IsAdult ? "1" : "0");
            }
            catch (Exception)
            {
                properties = new List<string>();
                return false;
            }

            return true;
        }
        public static int FindAndReturnUserDBID(string UserId)
        {
            User user = new User();
            using (HotelDBContext context = new HotelDBContext())
            {
               
                user = context.Users.First(w => w.UserID == UserId);
                context.SaveChanges();
                
            }
            return user.ID;
        }
        public static bool EditClient(string ID, string FirstName, string MiddleName, string LastName, string Phone, bool IsAdult)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    int ClientID = int.Parse(ID);

                    Client client = new Client();
                    client = context.Clients.First(w => w.ID == ClientID);

                    client.FirstName = FirstName;
                    client.MiddleName = MiddleName;
                    client.LastName = LastName;
                    client.Phone = Phone;
                    client.IsAdult = IsAdult;

                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }
        public static Room FindRoom(string RoomNumber)
        {
            var room = new Room();
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    room = context.Rooms.First(w => w.Number == RoomNumber);
                    
                    context.SaveChanges();
                }
            }
            catch (Exception)
            {
                return null; ;
                throw;
            }
            return room;
        }
        // Reservation

        public static bool AddReservation(int RoomId, int UserId, List<Client> clients, DateTime ArrivalDate, DateTime DeparatureDate, bool HasBreackfast, bool IsAllInclusive, double Price)
        {
            try
            {
                Reservation reserv = new Reservation();

                reserv.RoomID = RoomId;
                reserv.UserID = UserId;
                reserv.Clients = clients;
                reserv.ArrivalDate = ArrivalDate;
                reserv.DeparatureDate = DeparatureDate;
                reserv.HasBreakfast = HasBreackfast;
                reserv.IsAllInclusive = IsAllInclusive;
                reserv.Price = Price;

                using (HotelDBContext context = new HotelDBContext())
                {
                    context.Reservations.Add(reserv);

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
    }


}
