using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace personal_website.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Message = "This is just a test";

      return View();
    }
  }
}
