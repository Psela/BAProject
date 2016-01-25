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
        //get the data from the database
        
        //public System.Data.Entity<Dbset> getData() {

        //    using (var context = new BAProjectEntities())
        //    {
        //       context.users.
        //        for (int i = 0; i < length; i++)
        //        {
                    
        //        }
        //    }
        //}

        // GET: CourseRegistration
        public ActionResult Index()
        {
            return View();
        }


    }
}