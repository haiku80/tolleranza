﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Raven.Client;

namespace personal_website.Controllers.Base
{
  public abstract class BaseController : Controller
  {
    public IDocumentSession RavenSession { get; protected set; }

    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      RavenSession = MvcApplication.Store.OpenSession();
    }

    protected override void OnActionExecuted(ActionExecutedContext filterContext)
    {
      if (filterContext.IsChildAction)
        return;

      using (RavenSession)
      {
        if (filterContext.Exception != null)
          return;

        if (RavenSession != null)
          RavenSession.SaveChanges();
      }
    }
  }
}
