using BA_Project.Models;
using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

namespace BA_Project.Controllers
{
    public class CourseCatalogueController : Controller
    {
        Courses courses = new Courses();
        List<cours> listOfCourses;

        public ActionResult Index()
        {
            return View(listOfCourses);
        }

        public ActionResult IndividualCourse(string id)
        {
            cours courseToDisplay = listOfCourses.FirstOrDefault(x => x.course_id.ToString() == id);
            return View(courseToDisplay);
        }

        public CourseCatalogueController()
        {
            listOfCourses = courses.GetListOfCourses();
        }
    }
}