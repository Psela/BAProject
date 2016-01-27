using DatabaseModel;
using System;
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

    //view for the lecturer
    public ActionResult LecturerView(string id)
        {
      CourseCatalogueController courseCatalogue = new CourseCatalogueController();
      cours courseToDisplay = courseCatalogue.listOfCourses.FirstOrDefault(x => x.course_id.Equals(id));
      return View(courseToDisplay);
        }

        //view for student report card
        public ActionResult StudentView()
        {
            return View();
        }

    }
}