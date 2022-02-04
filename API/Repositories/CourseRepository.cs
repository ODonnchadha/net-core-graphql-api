using API.Contexts;
using API.Interfaces.Repositories;
using API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace API.Repositories
{
    public class CourseRepository : ICourseRepository
    {
        private readonly CourseContext context;
        public CourseRepository(CourseContext context) => this.context = context;
        public List<Course> GetAllCourses() => context.Courses.Include(i => i.Reviews).ToList();
        public Course GetCourseById(int id) => context.Courses.FirstOrDefault(n => n.Id == id);

        public Course AddCourse(Course course)
        {
            var c = new Course
            {
                Name = course.Name,
                Description = course.Description,
                DateAdded = course.DateAdded,
                DateUpdated = course.DateUpdated
            };
            context.Courses.Add(c);
            context.SaveChanges();

            course.Reviews.ForEach(r =>
            {
                context.Reviews.Add(new Review
                {
                    Rate = r.Rate,
                    Comment = r.Comment,
                    CourseId = c.Id,
                    Course = c
                });
                context.SaveChanges();
            });

            return c;
        }

        public Course UpdateCourse(int id, Course course)
        {
            var c = context.Courses.FirstOrDefault(n => n.Id == id);

            c.Name = course.Name;
            c.Description = course.Description;
            // c.Review = course.Review;
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
