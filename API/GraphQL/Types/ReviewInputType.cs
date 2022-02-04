using GraphQL.Types;

namespace API.GraphQL.Types
{
    public class ReviewInputType : InputObjectGraphType
    {
        public ReviewInputType()
        {
            this.Name = "ReviewInputType";

            Field<IntGraphType>("Rate");
            Field<StringGraphType>("Comment");
        }
    }
}
