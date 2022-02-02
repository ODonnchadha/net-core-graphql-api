using Courses.GraphQL.Contexts;
using Courses.GraphQL.Models;
using Courses.GraphQL.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Courses.GraphQL.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext context;
        public CourseRepository(AppDbContext context) => this.context = context;
       
        public List<Course> GetAllCourses() =>context.Courses.ToList();

        public Course GetCourseById(int id)
        {
            return context.Courses.FirstOrDefault(n => n.Id == id);
        }
        public Course AddCourse(Course course)
        {
            context.Courses.Add(course);
            context.SaveChanges();
            return course;
        }

        public Course UpdateCourse(int id, Course course)
        {
            var c = context.Courses.FirstOrDefault(n => n.Id == id);

            c.Name = course.Name;
            c.Description = course.Description;
            c.Review = course.Review;
            c.DateUpdated = DateTime.Now;

            context.SaveChanges();

            return course;
        }

        public void DeleteCourse(int id)
        {
            var c = context.Courses.FirstOrDefault(n => n.Id == id);
            context.Courses.Remove(c);
            context.SaveChanges();
        }
    }
}
