﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BA_Project.Controllers
{
    public class ReportCardController : Controller
    {
        // GET: ReportCard
        public ActionResult Index()
        {
            return View();
        }

        //view for the lectureer
        public ActionResult LecturerView()
        {
            return View();
           
        }
    }
}