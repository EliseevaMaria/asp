using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class HomeController : Controller
    {
        private GoodsEntities goods = new GoodsEntities();
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                if (Session["Authorization"].ToString() == "Default")
                {
                    var list = (from Good in goods.Goods select Good).ToList();
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

        public ActionResult Details(int id)
        {
            if (Session["Authorization"].ToString() == "Default")
            {
                var good = (from Good in goods.Goods where Good.Id == id select Good).First();
                return View(good);
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }
    }
}