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

    public class Professor 
    {
        public user GetProfessorById(string id)
        {
            user lecturer;

            using (var context = new BAProjectEntities())
            {
                lecturer = context.courses.FirstOrDefault(l => l.course_id.ToString().Equals(id)).user;
            }

            return lecturer;
        }
    }

    public class DatabaseReader
    {
        public List<cours> GetAllCourses()
        {
            List<cours> courses = new List<cours>();
            using (var context = new BAProjectEntities())
            {
                foreach (cours course in context.courses)
                {
                    courses.Add(course);
                }
            }

            return courses;
        }
    }
}