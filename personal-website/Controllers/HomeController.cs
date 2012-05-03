using System.Linq;
using System.Web.Mvc;
using personal_website.Controllers.Base;
using personal_website.Models;

namespace personal_website.Controllers
{
  public class HomeController : BaseController
  {
    //
    // GET: /Home/
    public ActionResult Index()
    {
      var model = this.RavenSession.Query<News>().ToList();
      return View(model);
    }

    //
    // GET: /Home/Details/5
    public ActionResult Details(string id)
    {
      var model = this.RavenSession.Load<News>(id);
      return View(model);
    }

    //
    // GET: /Home/Create
    public ActionResult Create()
    {
      var model = new News();
      return View(model);
    }

    //
    // POST: /Home/Create
    [HttpPost]
    public ActionResult Create(News news)
    {
      try
      {
        this.RavenSession.Store(news);
        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Home/Edit/5
    public ActionResult Edit(string id)
    {
      var model = this.RavenSession.Load<News>(id);
      return View(model);
    }

    //
    // POST: /Home/Edit/5
    [HttpPost]
    public ActionResult Edit(News news)
    {
      try
      {
        this.RavenSession.Store(news);

        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }

    //
    // GET: /Home/Delete/5
    public ActionResult Delete(string id)
    {
      var model = this.RavenSession.Load<News>(id);
      return View(model);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(string id)
    {
      try
      {
        this.RavenSession.Advanced.DatabaseCommands.Delete(id, null);
        return RedirectToAction("Index");
      }
      catch
      {
        return View();
      }
    }
  }
}
