using KandTKardach.Models;
using System.Web.Mvc;

namespace KandTKardach.Controllers
{
    public class BabyController : Controller
    {
        public ActionResult Index()
        {
            KAndTDatabase db = KAndTDatabase.Instance;

            var album = db.Albums["Baby"];
            var viewModel = new ViewModel.AlbumHeaderViewModel(album,
                                                                "My loneliness, is killin' meeee (and I)",
                                                                "I must confess, I still believe (still believe)");
            return View(viewModel);
        }
    }
}
