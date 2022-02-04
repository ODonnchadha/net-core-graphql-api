using API.Models;
using GraphQL.Types;

namespace API.GraphQL.Types
{
    public class ReviewType : ObjectGraphType<Review>
    {
        public ReviewType()
        {
            Field(f => f.Id, type: typeof(IdGraphType));
            Field(f => f.Rate, type: typeof(IntGraphType));
            Field(f => f.Comment, type: typeof(StringGraphType));
        }
    }
}
