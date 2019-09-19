using System;
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
            
            var album = db.Albums["Wedding"];
            var viewModel = new ViewModel.AlbumHeaderViewModel(album, 
                                                                "It doesn't matter what we're doing", 
                                                                "as long as we're doing it together");
            return View (viewModel);
        }

    }
}
