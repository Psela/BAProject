﻿using DatabaseModel;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;

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

        public Dictionary<cours, grades_database> GetCoursesAndGrades()
        {
            Dictionary<cours, grades_database> previousResult = new Dictionary<cours, grades_database>();

            using (var context = new DatabaseModel.BAProjectEntities())
            {
                foreach (DatabaseModel.grades_database grade in context.grades_database)
                {
                    if (grade.history.Equals(true))
                    {
                        cours course = context.courses.FirstOrDefault(c => c.course_id == grade.course_id);
                        if (!previousResult.ContainsKey(course))
                        {
                            previousResult.Add(course, grade);              
                        }
                    }
                }
            }

            return previousResult;
        }
    }
}