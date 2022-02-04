using API.Models;
using System.Collections.Generic;

namespace API.Interfaces.Repositories
{
    public interface ICourseRepository
    {
        void DeleteCourse(int id);
        Course AddCourse(Course course);
        Course GetCourseById(int id);
        Course UpdateCourse(int id, Course course);
        List<Course> GetAllCourses();
    }
}
