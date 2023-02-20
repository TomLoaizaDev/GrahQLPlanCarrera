using GrahQLPlanCarrera.RootTypes.Mutations;
using GrahQLPlanCarrera.RootTypes.Query;
using GrahQLPlanCarrera.RootTypes.Suscription;
using GraphQL.Types;

namespace GrahQLPlanCarrera.schema
{
    public class ProductSchema : Schema
    {
        //public ProductSchema(ProductQuery productQuery, ProductMutation productMutation, ProductSuscription productSuscription)
        //{
        //    Query = productQuery;
        //    Mutation = productMutation;
        //    Subscription = productSuscription;

        //}
        public ProductSchema(ProductQuery productQuery, ProductMutation productMutation)
        {
            Query = productQuery;
            Mutation = productMutation;

        }
    }
}
