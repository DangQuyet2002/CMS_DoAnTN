﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApp.Areas.Admin.Controllers
{
    [AuthorizationAttribute]
    public class ThamSoHeThongController : Controller
    {
        // GET: Admin/ThamSoHeThong
        public ActionResult Index()
        {
            return View();
        }
    }
}