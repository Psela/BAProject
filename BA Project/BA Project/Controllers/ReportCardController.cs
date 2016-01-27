﻿using DatabaseModel;
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
    public ActionResult StudentView()
    {
      return View();
    }

  }
}