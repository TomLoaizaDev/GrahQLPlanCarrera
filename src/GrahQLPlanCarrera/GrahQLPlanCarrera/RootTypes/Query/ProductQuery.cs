using GrahQLPlanCarrera.Domain.Interfaces.Models;
using GrahQLPlanCarrera.Type;
using GraphQL;
using GraphQL.Types;

namespace GrahQLPlanCarrera.RootTypes.Query
{
    public class ProductQuery : ObjectGraphType
    {
        public ProductQuery(IProduct productService)
        {
            Field<ListGraphType<ProductType>>("products", resolve: context => { return productService.GetAllProducts(); });
            Field<ProductType>("product",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }), //Solicito un argumento enviado por el usuario con nombre id
                resolve:
                context =>
                {
                    return productService.GetProductById(context.GetArgument<int>("id")); //recibo el argumento dentro del contexto
                });
        }
    }
}
