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
  public class ReportCardController : Controller
  {
    public ActionResult Index()
    {      
      user user = new user();
      string cookie = HttpContext.Request.Cookies["user"].Value;
      using (var context = new BAProjectEntities())
      {
        user = context.users.FirstOrDefault(x => x.username.Equals(cookie));
      }
      if (user.type_of_user == 2)
      {
        return StudentView(user.users_id);
      }
      else
      {
        return LecturerView("1");
      }
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
          usernamesAndGrades.Add(grade.user.full_name, grade.grade);
        }
      }
      return View(usernamesAndGrades);
    }

    public void UpdateGrade(List<string> grade, string courseName)
    {
      cours course = new cours();
      try
      {
        using (var context = new BAProjectEntities())
        {
          course = context.courses.FirstOrDefault(x => x.name.Equals(courseName));

          foreach (var gradeDatabase in course.grades_database)
          {
            gradeDatabase.grade = grade.First();
            grade.Remove(grade.First());
          }
          context.SaveChanges();
        }
      }
      catch (Exception ex)
      {
        if (ex is EntityException || ex is NullReferenceException)
        {
          MessageBox.Show("Couldn't connect to the database. Please try again later.");
        }
        else
        {
          throw;
        }
      }
      Response.Redirect("~/ReportCard/LecturerView/"+course.course_id);
    }

    //view for student report card
    public ActionResult StudentView(int id)
    {
      Dictionary<string, string> grades = new Dictionary<string, string>();
      using (var context = new BAProjectEntities())
      {
        List<grades_database> gradeDB = context.grades_database.Where<grades_database>(x => x.student_id.Equals(id)).ToList();
        foreach (var item in gradeDB)
        {
          grades.Add(item.cours.name,item.grade);
        }
      }

      return View(grades);
    }

  }
}