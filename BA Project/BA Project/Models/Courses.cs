using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BA_Project.Models
{
    public class Courses
    {
        public List<cours> listOfCourses;

        public List<cours> GetListOfCourses()
        {
            listOfCourses = new List<cours>();
            using (var context = new BAProjectEntities())
            {
                foreach (cours course in context.courses)
                {
                    listOfCourses.Add(course);
                }
            }

            return listOfCourses;
        }
    }

    public class Lecturer
    {

    }
}