using System.Linq;
using System.Web.Mvc;
using KandTKardach.Models;
using KandTKardach.ViewModel;

namespace KandTKardach.Controllers
{
    public class ImageController : Controller
    {
        public ActionResult Index(string album, int id)
        {
			var db = KAndTDatabase.Instance;
			var image = db.Albums[album].Images.Single(o => o.Id == id);
			var imageVM = new ImageViewModel(album, image);
			return View (imageVM);
        }
    }
}
