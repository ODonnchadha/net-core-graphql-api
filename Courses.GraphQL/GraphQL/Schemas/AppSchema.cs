using Courses.GraphQL.GraphQL.Mutations;
using Courses.GraphQL.GraphQL.Queries;
using GraphQL.Types;

namespace Courses.GraphQL.GraphQL.Schemas
{
    public class AppSchema : Schema
    {
        public AppSchema(CourseQuery query, CourseMutation mutation)
        {
            this.Query = query;
            this.Mutation = mutation;
        }
    }
}
