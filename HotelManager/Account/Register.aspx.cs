using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using HotelManagerReservationsPt3.Models;
using HotelManager.Models;
using HotelManager.DBMethods;

namespace HotelManagerReservationsPt3.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();
            var user = new ApplicationUser() { UserName = Username.Text, Email = Email.Text };
            IdentityResult result = manager.Create(user, Password.Text);
            if (result.Succeeded)
            {
                string UserId = manager.Users.First(w => w.UserName == Username.Text).Id;


                if(DBManager.AddUser(UserId,FirstName.Text,MiddleName.Text,LastName.Text,EGN.Text,Phone.Text)==false)
                {
                    manager.Delete(user);
                    throw new Exception();
                }

                signInManager.SignIn( user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else 
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }
    }
}