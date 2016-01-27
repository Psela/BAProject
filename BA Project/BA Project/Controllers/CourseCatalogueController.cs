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

    //Finds the lecturer using the course id
    public ActionResult LecturerName(string id)
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

    public ActionResult courseHistory()
    {
      return View();
    }

    public ActionResult confirmationPage()
    {
      return View();
    }

    public void NewCourse(string name, string outline, string start, string end)
    {
      using (var context = new BAProjectEntities())
      {
        string username = Request.Cookies["user"].Value;
        user user = context.users.FirstOrDefault(x => x.username.Equals(username));
        int type = user.type_of_user;
        bool approved = false;
        int lecturer = 0;
        if (type == 3)
        {
          approved = true;
        }
        else if (type == 1)
        {
          lecturer = user.users_id;
        }
        cours course = new cours()
        {
          name = name,
          outline = outline,
          //start_date = (DateTime)20021022,
          //finish_date = end,
          available = true,
          approved = approved,
          lecturer = lecturer
        };
        context.courses.Add(course);
        context.SaveChanges();
      }
    }
  }
}