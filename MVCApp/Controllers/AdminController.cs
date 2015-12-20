using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class AdminController : Controller
    {
        private UsersEntities users = new UsersEntities();
        // GET: Admin
        public ActionResult Index()
        {
            try {
                if (Session["Authorization"].ToString() == "Administrator")
                {
                    var list = (from User in users.Users select User).ToList();
                    return View(list);
                }
                else
                {
                    return Redirect("/Account/Index");
                }
            }
            catch
            {
                Session.Add("Authorization", "Unauthorized");
                return RedirectToAction("Index");
            }
        }

        public ActionResult Create()
        {
            if (Session["Authorization"].ToString() == "Administrator")
            {
                User user = new User();
                return View(user);
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (Session["Authorization"].ToString() == "Administrator")
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        users.Users.Add(user);
                        users.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else return View(user);
                }
                catch
                {
                    return View(user);
                }
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        public ActionResult Delete(int id)
        {
            var user = (from User in users.Users where User.Id == id select User).First();
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id, User userr)
        {
            if (Session["Authorization"].ToString() == "Administrator")
            {
                var user = (from User in users.Users where User.Id == id select User).First();
                try
                {
                    users.Users.Remove(user);
                    users.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(user);
                }
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        public ActionResult Details(int id)
        {
            if (Session["Authorization"].ToString() == "Administrator")
            {
                var user = (from User in users.Users where User.Id == id select User).First();
                return View(user);
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["Authorization"].ToString() == "Administrator")
            {
                var user = (from User in users.Users where User.Id == id select User).First();
                return View(user);
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, User userr)
        {
            if (Session["Authorization"].ToString() == "Administrator")
            {
                var user = (from User in users.Users where User.Id == id select User).First();
                try
                {
                    UpdateModel(user);
                    users.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(user);
                }
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }
    }
}