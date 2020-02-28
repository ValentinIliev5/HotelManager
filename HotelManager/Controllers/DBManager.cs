using HotelManager.Models;
using HotelManagerReservationsPt3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace HotelManager.DBMethods
{
    public static class DBManager
    {
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

                ApplicationDbContext apContext = new ApplicationDbContext();


                var UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(apContext));
                UserManager.AddToRole(UserID, "ADMIN");
                apContext.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="user"></param>
        /// <returns></returns>
        public static bool EditUser(int ID, User user)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    var userToEdit = context.Users.Find(ID);

                    //TODO
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
                    if(user.FiredDate == null)
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

    }
}
