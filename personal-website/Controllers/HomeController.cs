using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using personal_website.Controllers.Base;

namespace personal_website.Controllers
{
  public class HomeController : BaseController
  {
    public ActionResult Index()
    {
      ViewBag.Message = "This is just a test";

      return View();
    }
  }
}
