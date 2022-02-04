using API.GraphQL.Types;
using API.Interfaces.Repositories;
using API.Models;
using GraphQL;
using GraphQL.Types;

namespace API.GraphQL.Mutations
{
    public class CourseMutation : ObjectGraphType
    {
        public CourseMutation(ICourseRepository repository)
        {
            Field<CourseType>(
                "createCourse",
                "ADD A COURSE",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<CourseInputType>> { Name = "course", Description = "COURSE TO ADD" }
                ), resolve: context =>
                {
                    var course = context.GetArgument<Course>("course");
                    return repository.AddCourse(course);
                });

            Field<CourseType>(
                "deleteCourse",
                "DELETE AN EXISTING COURSE",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "ID OF THE COURSE TO DELETE" }
                ), resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    repository.DeleteCourse(id);
                    return true;
                });

            Field<CourseType>(
                "updateCourse",
                "UPDATE AN EXISTING COURSE",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "id", Description = "ID OF THE COURSE TO UPDATE" },
                    new QueryArgument<NonNullGraphType<CourseInputType>> { Name = "course", Description = "COURSE TO UPDATE" }
                ), resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    var course = context.GetArgument<Course>("course");
                    return repository.UpdateCourse(id, course);
                });
        }
    }
}
