using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BA_Project.Controllers
{
    public class CourseCatalogueController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public void UpdateData(string desc, string addressline1, string addressline2, string postcode, string phone, string email, string city)
        {
          try
          {
            using (var context = new BAProjectEntities())
            {
              user user = context.users.FirstOrDefault(u=>u.users_id.Equals(1));//userid));
              user.description = desc;
              user.email= email;
              user.address_city= city;
              user.address_firstline= addressline1;
              user.address_secondline=addressline2;
              user.postcode= postcode;
              user.phone_number=phone;
              
              context.SaveChanges();
            }
          }
          catch (Exception e)
          {
            throw;
          }
        }
    }
}