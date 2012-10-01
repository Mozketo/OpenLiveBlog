using OpenLiveBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OpenLiveBlog.Controllers
{
    public class HomeController : Controller
    {
        protected static List<EntryViewModel> _entries = new List<EntryViewModel>();

        public static void AddEntry(EntryViewModel entry) 
        {
            _entries.Add(entry);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Post()
        {
            return View();
        }

        public ActionResult _Entries(int? top)
        {
            List<EntryViewModel> entries;
            if (top.HasValue && top > 0)
                entries = _entries.OrderByDescending(m => m.dateTime).Take(top.Value).OrderBy(m => m.dateTime).ToList();
            else
                entries = _entries.OrderByDescending(m => m.dateTime).ToList();

            var result = this.Json(new { data = entries }, JsonRequestBehavior.AllowGet);
            return result;
        }
    }
}
