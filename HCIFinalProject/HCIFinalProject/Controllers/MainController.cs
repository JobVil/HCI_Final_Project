using HCIFinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HCIFinalProject.Controllers
{
    public class MainController : Controller
    {

        public ActionResult Doors(string tags, string priceRange, string dim1, string dim2, string num)
        {
            MainDB db;
            if (String.IsNullOrEmpty(tags))
                tags = ":was:null:n";
            if (String.IsNullOrEmpty(priceRange)|| String.IsNullOrEmpty(dim1) || String.IsNullOrEmpty(dim2) ||
                String.IsNullOrEmpty(num))
                db = new MainDB();
            else
                db = new MainDB(tags, priceRange, dim1, dim2, num);

            List<Door> main = db.GetMainData();
            return View(main);
        }

        public ActionResult Inserts(string tags, string priceRange, string dim1, string dim2, string num)
        {
            MainDB db;
            if (String.IsNullOrEmpty(tags))
                tags = ":was:null:n";
            if (String.IsNullOrEmpty(priceRange) || String.IsNullOrEmpty(dim1) || String.IsNullOrEmpty(dim2) ||
                String.IsNullOrEmpty(num))
                db = new MainDB();
            else
                db = new MainDB(tags, priceRange, dim1, dim2, num);

            List<Door> main = db.GetMainData();
            return View(main);
        }

        public ActionResult Frames(string tags, string priceRange, string dim1, string dim2, string num)
        {
            MainDB db;
            if (String.IsNullOrEmpty(tags))
                tags = ":was:null:n";
            if (String.IsNullOrEmpty(priceRange) || String.IsNullOrEmpty(dim1) || String.IsNullOrEmpty(dim2) ||
                String.IsNullOrEmpty(num))
                db = new MainDB();
            else
                db = new MainDB(tags, priceRange, dim1, dim2, num);

            List<Door> main = db.GetMainData();
            return View(main);
        }

        public ActionResult Hardware(string tags, string priceRange, string dim1, string dim2, string num)
        {
            MainDB db;
            if (String.IsNullOrEmpty(tags))
                tags = ":was:null:n";
            if (String.IsNullOrEmpty(priceRange) || String.IsNullOrEmpty(dim1) || String.IsNullOrEmpty(dim2) ||
                String.IsNullOrEmpty(num))
                db = new MainDB();
            else
                db = new MainDB(tags, priceRange, dim1, dim2, num);

            List<Door> main = db.GetMainData();
            return View(main);
        }
    }
}