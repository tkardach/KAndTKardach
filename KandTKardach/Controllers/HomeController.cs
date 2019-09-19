using KandTKardach.Models;
using KandTKardach.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Ajax;

namespace KandTKardach.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
			ViewBag.Title = "Kayla and Tommy";
            return View();
		}

        public ActionResult About()
        {
            return View();
        }
        
        public ActionResult ViewImage(string album, int id)
        {
            var db = KAndTDatabase.Instance;
            Image image;
            if (db.Albums.ContainsKey(album))
                image = db.Albums[album].Images.Single(o => o.Id == id);
            else return View();

            var imageVM = new ImageViewModel(album, image);
            return View(imageVM);
        }
    }
}
