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
        // GET: CourseRegistration
        public ActionResult Index()
        {
          if (Request.IsAjaxRequest())
          {
            return UpdateData();
          }
            return View();
        }

        private PartialViewResult UpdateData()
        {
          try
          {
            using (var context = new BAProjectEntities())
            {
              user user = context.users.Where(u=>u.users_id.Equals(userid);
              user.description =
            }
          }
          catch (Exception e)
          {
            throw;
          }
        }
    }
}