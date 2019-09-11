using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KandTKardach.Controllers
{
    public class ErrorHandlerController : Controller
    {
        public ActionResult Index()
        {
            return View ();
        }

		public ActionResult Error(string exception)
		{
			return View(model:exception);
		}

        public ActionResult NotFound()
        {
            return View();
        }


    }
}
