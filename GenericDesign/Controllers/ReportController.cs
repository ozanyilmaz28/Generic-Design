﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericDesign.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult ReportLayout()
        {
            return View();
        }
    }
}