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
      List<user> listOfProfessors = new List<user>();
      using (var context = new BAProjectEntities())
      {
        listOfProfessors = context.users.Where(x => x.type_of_user.Equals(1)).ToList();
      }
      return View(listOfProfessors);
    }

    public ActionResult courseHistory()
    {
      return View();
    }

    public ActionResult confirmationPage()
    {
      return View();
    }

    public void AddNewCourse(string name, string outline, string startdate, string enddate, int lecturer)
    {
      bool messageBox = true;
      if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(outline) || string.IsNullOrEmpty(startdate) || string.IsNullOrEmpty(enddate))
      {
        MessageBox.Show("Not all details have been filled out. Please try again.");
      }
      else
      {
        try
        {
          string username = Request.Cookies["user"].Value;
          bool approved = false;
          DateTime start = Convert.ToDateTime(startdate);
          DateTime end = Convert.ToDateTime(enddate);

          if (start < end)
          {
            using (var context = new BAProjectEntities())
            {
              user user = context.users.FirstOrDefault(x => x.username.Equals(username));
              int type = user.type_of_user;

              if (type == 3)
              {
                approved = true;
              }

              cours course = new cours()
              {
                name = name,
                outline = outline,
                start_date = start,
                finish_date = end,
                available = true,
                approved = approved,
                lecturer = lecturer
              };
              context.courses.Add(course);
              context.SaveChanges();

              messageBox = false;
              Response.Redirect("~/CourseCatalogue/confirmationPage");
            }
          }
          else
          {
            MessageBox.Show("The start date is after the end date. Please try again.");
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
      }
      if (messageBox)
      {
        Response.Redirect("~/CourseCatalogue/courseInfo");
      }
    }
  }
}