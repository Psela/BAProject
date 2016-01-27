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
      Dictionary<string, string> usernamesAndGrades = new Dictionary<string, string>();
      using (var context = new BAProjectEntities())
      {
        cours course = context.courses.FirstOrDefault(x => x.course_id.ToString() == id);
        ViewBag.courseName = course.name;

        foreach (var grade in course.grades_database)
        {
          usernamesAndGrades.Add(grade.user.username, grade.grade);
        }
      }
      return View(usernamesAndGrades);
    }

        //view for student report card
        public ActionResult StudentView()
        {
            return View();
        }

  }
}