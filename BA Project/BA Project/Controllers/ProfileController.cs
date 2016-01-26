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
      string cookie = HttpContext.Request.Cookies["user"].Value;
      user user = new user();
      using (var context = new BAProjectEntities())
      {
        user = context.users.FirstOrDefault(x=>x.username.Equals(cookie));
      }
      return View(user);
    }
    public void UpdateData(string desc, string addressline1, string addressline2, string postcode, string phone, string email, string city)
    {
      try
      {
        using (var context = new BAProjectEntities())
        {
          user user = context.users.FirstOrDefault(u => u.users_id.Equals(1));//userid));
          user.description = desc;
          user.email = email;
          user.address_city = city;
          user.address_firstline = addressline1;
          user.address_secondline = addressline2;
          user.postcode = postcode;
          user.phone_number = phone;

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

      Response.Redirect("~/Profile/Index");
    }
  }
}