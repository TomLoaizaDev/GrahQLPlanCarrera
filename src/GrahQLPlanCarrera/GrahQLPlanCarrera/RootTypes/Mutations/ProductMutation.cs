using GrahQLPlanCarrera.Domain.Interfaces.Models;
using GrahQLPlanCarrera.Domain.Models;
using GrahQLPlanCarrera.Type;
using GraphQL;
using GraphQL.Types;

namespace GrahQLPlanCarrera.RootTypes.Mutations
{
    public class ProductMutation : ObjectGraphType
    {
        public ProductMutation(IProduct productService)
        {
            Field<ProductType>("createProduct",
                    arguments: new QueryArguments(
                        new QueryArgument<ProductInputType> { Name = "product" }), //Solicito un argumento enviado por el usuario con nombre id
                    resolve:
                    context =>
                    {
                        return productService.AddProduct(context.GetArgument<Product>("product")); //recibo el argumento dentro del contexto
                    });

            Field<ProductType>("updateProduct",
                    arguments: new QueryArguments(
                        new QueryArgument<IntGraphType> { Name = "id" },
                        new QueryArgument<ProductInputType> { Name = "product" }), //Solicito un argumento enviado por el usuario con nombre id
                    resolve:
                    context =>
                    {
                        var productObj = context.GetArgument<Product>("product");
                        var productID = context.GetArgument<int>("id");
                        return productService.UpdateProduct(productID,productObj); //recibo el argumento dentro del contexto
                    });
            Field<StringGraphType>("deleteProduct",
                    arguments: new QueryArguments(
                        new QueryArgument<IntGraphType> { Name = "id" }), //Solicito un argumento enviado por el usuario con nombre id
                    resolve:
                    context =>
                    {
                        var productID = context.GetArgument<int>("id");
                        productService.DeleteProduct(productID);
                        return $"The Product to Delete has been eliminated succesfully, ID={productID}";//recibo el argumento dentro del contexto
                    });

        }
    }
}
