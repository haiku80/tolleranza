using System.Web.Mvc;
using personal_website.Controllers.Base;

namespace personal_website.Controllers
{
  public class HomeController : BaseController
  {
    public ActionResult Index()
    {
      ViewBag.Message = "Agua de beber";

      return View();
    }
  }
}
