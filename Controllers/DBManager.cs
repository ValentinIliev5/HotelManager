using HotelManager.Models;
using HotelManagerReservationsPt3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
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

        public static bool FireUser(int ID)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    context.Users.Find(ID).FiredDate = DateTime.Now;
                    context.Users.Find(ID).IsActive = false;
                    context.Users.Find(ID).IsAdmin = false;

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

        public static bool UsersList(out List<User> users)
        {
            try
            {
                using (HotelDBContext context = new HotelDBContext())
                {
                    users = context.Users.ToList();
                }
            }
            catch (Exception)
            {
                users = new List<User>();

                return false;
            }

            return true;
        }

    }
}
