using GrahQLPlanCarrera.Domain.Interfaces.Models;
using GrahQLPlanCarrera.Domain.Services;
using GrahQLPlanCarrera.Domain.DBContext;
using GrahQLPlanCarrera.Infrastructure.Settings;
using GrahQLPlanCarrera.RootTypes.Mutations;
using GrahQLPlanCarrera.RootTypes.Query;
using GrahQLPlanCarrera.schema;
using GrahQLPlanCarrera.Type;
using GraphQL;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using GrahQLPlanCarrera.RootTypes.Suscription;

namespace GrahQLPlanCarrera.Extentions
{
    public static class DependenciesExtension
    {
        public static IServiceCollection AddDependenciesExtension(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<GraphQLDbContext>();
            services.AddTransient<IProduct, ProductService>();
            services.AddTransient<ProductType>();
            services.AddTransient<ProductQuery>();
            services.AddTransient<ProductMutation>();
            //services.AddTransient<ProductSuscription>();
            services.AddTransient<ISchema,ProductSchema>();

            services.AddGraphQL(b => b
                .AddSystemTextJson()
                .AddErrorInfoProvider(opt => opt.ExposeExceptionDetails = true)
                .AddSchema<ProductSchema>()
                .AddGraphTypes(typeof(ProductSchema).Assembly));
            
            services.AddDbContext<GraphQLDbContext>(option=>option.UseSqlServer(@"Server=tcp:pruebastom.database.windows.net,1433;Initial Catalog=PlanCarrera;Persist Security Info=False;User ID=admintom;Password=Colombia2021;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"));


            return services;
        }
    }
}
