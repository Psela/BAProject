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

    public void AddNewCourse(string name, string outline, string startdate, string enddate)
    {
      if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(outline) || string.IsNullOrEmpty(startdate) || string.IsNullOrEmpty(enddate))
      {
        MessageBox.Show("Not all details have been filled out. Please try again.");
        Response.Redirect("~/CourseCatalogue/courseInfo");
      }
      else
      {
        try
        {
          string username = Request.Cookies["user"].Value;
          bool approved = false;
          int lecturer = 0;
          DateTime start = Convert.ToDateTime(startdate);
          DateTime end = Convert.ToDateTime(enddate);

          using (var context = new BAProjectEntities())
          {
            user user = context.users.FirstOrDefault(x => x.username.Equals(username));
            int type = user.type_of_user;

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
              start_date = start,
              finish_date = end,
              available = true,
              approved = approved,
              lecturer = lecturer
            };
            context.courses.Add(course);
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
      }
    }

  }
}