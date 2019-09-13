using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using KandTKardach.Models;
using KandTKardach.ViewModel;

namespace KandTKardach.Controllers
{
    public class WeddingController : Controller
    {
        public ActionResult Index()
        {
			KAndTDatabase db = KAndTDatabase.Instance;
			var album = db.Albums["Wedding"];
            foreach (var image in album.Images)
                KandTKardach.Models.ImageProcessing.CreateThumbnail(Server.MapPath(image.Url),
                                                Server.MapPath(Constants.THUMBNAIL_LOCATION));
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
