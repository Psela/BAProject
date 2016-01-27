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
        Professor professor = new Professor();
        public List<cours> listOfCourses;

        public ActionResult Index()
        {
            return View(listOfCourses);
        }

        public ActionResult IndividualCourse(string id)
        {
            cours courseToDisplay = listOfCourses.FirstOrDefault(x => x.course_id.ToString() == id);
            return View(courseToDisplay);
        }

        public ActionResult LecturerName(string id) //Finds the lecturer using the course id
        {
            user prof = professor.GetProfessorById(id);

            return PartialView(prof);
        }

        public CourseCatalogueController()
        {
            listOfCourses = courses.GetListOfCourses();
        }

        public ActionResult courseInfo()
        {
            return View();
        }
        public ActionResult confirmationPage()
        {
            return View();
        }
    }
}