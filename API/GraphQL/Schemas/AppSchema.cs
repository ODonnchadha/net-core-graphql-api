using API.GraphQL.Mutations;
using API.GraphQL.Queries;
using GraphQL.Types;

namespace API.GraphQL.Schemas
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
