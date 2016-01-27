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
  public class ProfileController : Controller
  {
    // GET: Profile
    public ActionResult Index()
    {
      user user = GetUser();
      return View(user);
    }

    public user GetUser()
    {
      user user = new user();
      string cookie = HttpContext.Request.Cookies["user"].Value;
      using (var context = new BAProjectEntities())
      {
        user = context.users.FirstOrDefault(x => x.username.Equals(cookie));
      }
      return user;
    }

    public void UpdateData(string desc, string addressline1, string addressline2, string postcode, string phone, string email, string city, string name, string office)
    {
      user user = GetUser();
      if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(desc) || string.IsNullOrEmpty(city) || string.IsNullOrEmpty(addressline1) || string.IsNullOrEmpty(postcode) || string.IsNullOrEmpty(phone))
      {
        MessageBox.Show("Not all information has been filled in. Please try again.");
      }
      else
      {
        try
        {
          using (var context = new BAProjectEntities())
          {
            user databaseUser = context.users.FirstOrDefault(u => u.username.Equals(user.username));

            databaseUser.full_name = name;
            databaseUser.description = desc;
            databaseUser.email = email;
            databaseUser.address_city = city;
            databaseUser.address_firstline = addressline1;
            databaseUser.address_secondline = addressline2;
            databaseUser.postcode = postcode;
            databaseUser.phone_number = phone;
            databaseUser.office = office;

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

      Response.Redirect("~/Profile/Index");
    }

    //profile for Lecturers
    public ActionResult LecturerProfile(string id)
    {
      user lecturer = new user();
      using (var context = new BAProjectEntities())
      {
        lecturer = context.users.FirstOrDefault(x => x.users_id.ToString().Equals(id));
      }

      return View(lecturer);

    }
  }
}