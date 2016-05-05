﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Easy.CMS.Common.Controllers
{
    
    public class ErrorController : Controller
    {
        
        public ActionResult Index()
        {
            Response.StatusCode = 500;
            return View();
        }
    
        public ActionResult NotFond()
        {
            Response.StatusCode = 404;
            return View();
        }

    }
}
