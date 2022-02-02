using GraphQL.Types;

namespace Courses.GraphQL.GraphQL.Types
{
    public class CourseInputType : InputObjectGraphType
    {
        public CourseInputType()
        {
            this.Name = "CourseInputType";

            Field<StringGraphType>("Name");
            Field<StringGraphType>("Description");
            Field<IntGraphType>("Review");
            Field<DateTimeGraphType>("DateAdded");
            Field<DateTimeGraphType>("DateUpdated");
        }
    }
}
