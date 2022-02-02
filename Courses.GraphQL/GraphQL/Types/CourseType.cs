using GraphQL.Types;

namespace Courses.GraphQL.GraphQL.Types
{
    public class CourseType : ObjectGraphType<Models.Course>
    {
        public CourseType()
        {
            Field(f => f.Id, type: typeof(IdGraphType));
            Field(f => f.Name, type: typeof(StringGraphType));
            Field(f => f.Description, type: typeof(StringGraphType));
            Field(f => f.Review, type: typeof(IntGraphType));
            Field(f => f.DateAdded, type: typeof(DateTimeGraphType));
            Field(f => f.DateUpdated, type: typeof(DateTimeGraphType));
        }
    }
}
