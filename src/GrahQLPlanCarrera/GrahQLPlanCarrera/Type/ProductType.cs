using GrahQLPlanCarrera.Domain.Models;
using GraphQL.Types;
namespace GrahQLPlanCarrera.Type
{
    public class ProductType : ObjectGraphType<Product>
    {
        public ProductType()
        {
            Field(p => p.Id);
            Field(p => p.Name);
            Field(p => p.Price);
        }
    }
}
