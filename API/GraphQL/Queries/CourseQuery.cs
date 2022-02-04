using API.Interfaces.Repositories;
using GraphQL;
using GraphQL.Types;

namespace API.GraphQL.Queries
{
    public class CourseQuery : ObjectGraphType
    {
        public CourseQuery(ICourseRepository repository)
        {
            Field<ListGraphType<Types.CourseType>>(
                "courses",
                "RETRIEVE A LIST OF COURSES",
                resolve: context => repository.GetAllCourses()
            );

            Field<Types.CourseType>(
                "course",
                "RETRIEVE A COURSE BY ID",
                new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id", Description = "COURSE ID"} ),
                resolve: context => repository.GetCourseById(context.GetArgument("id", int.MinValue))
            );
        }
    }
}
