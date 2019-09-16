﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KandTKardach.Models;
using KandTKardach.ViewModel;
using System.IO;

namespace KandTKardach.Controllers
{
    public class WeddingController : Controller
    {
        public ActionResult Index()
        {
			KAndTDatabase db = KAndTDatabase.Instance;
            // TODO : If tumbnail does not exist for any given photo, create one
            
            var album = db.Albums["Wedding"];

            return View (album);
        }

        public ActionResult WeddingImage(int id)
		{
            var db = KAndTDatabase.Instance;
            var image = db.Albums["Wedding"].Images.Single(o => o.Id == id);
			var imageVM = new ImageViewModel("Wedding", image);
			return View(imageVM);
		}
    }
}
