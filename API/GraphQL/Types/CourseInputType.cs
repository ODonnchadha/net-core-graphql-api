using GraphQL.Types;

namespace API.GraphQL.Types
{
    public class CourseInputType : InputObjectGraphType
    {
        public CourseInputType()
        {
            this.Name = "CourseInputType";

            Field<StringGraphType>("Name");
            Field<StringGraphType>("Description");
            Field<DateTimeGraphType>("DateAdded");
            Field<DateTimeGraphType>("DateUpdated");

            // 1:M
            Field<ListGraphType<ReviewInputType>>("Reviews");
        }
    }
}
