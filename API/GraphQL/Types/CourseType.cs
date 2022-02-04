using API.Models;
using GraphQL.Types;

namespace API.GraphQL.Types
{
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType()
        {
            Field(f => f.Id, type: typeof(IdGraphType));
            Field(f => f.Name, type: typeof(StringGraphType));
            Field(f => f.Description, type: typeof(StringGraphType));
            Field(f => f.DateAdded, type: typeof(DateTimeGraphType));
            Field(f => f.DateUpdated, type: typeof(DateTimeGraphType));

            // 1:M
            Field(f => f.Reviews, type: typeof(ListGraphType<ReviewType>));
        }
    }
}
