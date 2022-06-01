using ObućaWebApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ObućaWebApp.Controllers
{
    public class FilterController : Controller
    {
        ObucaWebAppDbModel _db;
        public FilterController()
        {
            _db = new ObucaWebAppDbModel();
        }
        public ActionResult Index(string terminPretrage)
        {
            ViewData["CurrFilter"] = terminPretrage;

            var obuce = from o in _db.Obuce
                          select o;
            if (!String.IsNullOrEmpty(terminPretrage))
            {
                obuce = obuce.Where(o => o.Naziv.Contains(terminPretrage));
            }

            return View(obuce.AsNoTracking());
        }
    }
}