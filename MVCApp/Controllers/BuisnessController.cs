using MVCApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCApp.Controllers
{
    public class BuisnessController : Controller
    {
        private GoodsEntities goods = new GoodsEntities();
        // GET: Home
        public ActionResult Index()
        {
            try
            {
                if (Session["Authorization"].ToString() == "Buisness")
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

        public ActionResult Create()
        {
            Good good = new Good();
            return View(good);
        }

        [HttpPost]
        public ActionResult Create(Good good, DateTime InputDate)
        {
            if (Session["Authorization"].ToString() == "Buisness")
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        good.DateIncome = InputDate;
                        goods.Goods.Add(good);
                        goods.SaveChanges();
                        return RedirectToAction("Index");
                    }
                    else return View(good);
                }
                catch
                {
                    return View(good);
                }
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        public ActionResult Edit(int id)
        {
            if (Session["Authorization"].ToString() == "Buisness")
            {
                var good = (from Good in goods.Goods where Good.Id == id select Good).First();
                ViewBag.DateInc = good.DateIncome;
                return View(good);
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        [HttpPost]
        public ActionResult Edit(int id, DateTime InputDate)
        {
            if (Session["Authorization"].ToString() == "Buisness")
            {
                var good = (from Good in goods.Goods where Good.Id == id select Good).First();
                try
                {
                    good.DateIncome = InputDate;
                    UpdateModel(good);
                    goods.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(good);
                }
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }



        public ActionResult Details(int id)
        {
            if (Session["Authorization"].ToString() == "Buisness")
            {
                var good = (from Good in goods.Goods where Good.Id == id select Good).First();
                return View(good);
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        public ActionResult Delete(int id)
        {
            if (Session["Authorization"].ToString() == "Buisness")
            {
                var good = (from Good in goods.Goods where Good.Id == id select Good).First();
                return View(good);
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        [HttpPost]
        public ActionResult Delete(int id, User user)
        {
            if (Session["Authorization"].ToString() == "Buisness")
            {
                var good = (from Good in goods.Goods where Good.Id == id select Good).First();
                try
                {
                    goods.Goods.Remove(good);
                    goods.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch
                {
                    return View(good);
                }
            }
            else
            {
                return Redirect("/Account/Index");
            }
        }

        
    }
}