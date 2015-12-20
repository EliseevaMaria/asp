using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCApp.Models;

namespace MVCApp.Controllers
{
    public class AccountController : Controller
    {
        private UsersEntities users = new UsersEntities();

        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult LogIn()
        //{
        //    return View("Index");
        //}

        [HttpPost]
        public ActionResult LogIn(string login, string password)
        {
            try {
                var obj = (from User in users.Users where User.Login == login && User.Password == password select User).First();
                var role = obj.Role1.RoleName;
                if (role != "")
                {
                    if (role == "Administrator")
                    {
                        Session["Authorization"] = "Administrator";
                        return Redirect("/Admin/Index");
                    }
                    else if (role == "Default")
                    {
                        Session["Authorization"] = "Default";
                        return Redirect("/Home/Index");
                    }
                    else
                    {
                        Session["Authorization"] = "Buisness";
                        return Redirect("/Buisness/Index");
                    }
                }
                else
                {
                    return View("Index");
                }
            }
            catch
            {
                return View("Index");
            }
        }

        public ActionResult LogOut()
        {
            Session["Authorization"] = "Unauthorized";
            return View("Index");
        }
    }
}