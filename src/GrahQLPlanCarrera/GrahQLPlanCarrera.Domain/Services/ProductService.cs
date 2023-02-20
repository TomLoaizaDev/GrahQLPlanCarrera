
using GrahQLPlanCarrera.Domain.DBContext;
using GrahQLPlanCarrera.Domain.Interfaces;
using GrahQLPlanCarrera.Domain.Interfaces.Models;
using GrahQLPlanCarrera.Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahQLPlanCarrera.Domain.Services
{
    public class ProductService : IProduct
    {
        private GraphQLDbContext _dbContext;

        public ProductService(IServiceProvider serviceProvider)
        {
            _dbContext = serviceProvider.GetRequiredService<GraphQLDbContext>();
        }

        public Product AddProduct(Product product)
        {
            _dbContext.Products.Add(product);
            _dbContext.SaveChanges();
            return product;
        }

        public void DeleteProduct(int id)
        {
            var productToDelete= _dbContext.Products.Find(id);
            _dbContext.Products.Remove(productToDelete);
            _dbContext.SaveChanges();
        }

        public Product GetProductById(int id)
        {
            return _dbContext.Products.Find(id);
        }

        public Product UpdateProduct(int id, Product product)
        {
            var productToUpdate=_dbContext.Products.Find(id);

            productToUpdate.Name = product.Name;
            productToUpdate.Price=product.Price;
            
            _dbContext.SaveChanges();

            return product;
        }

        public List<Product> GetAllProducts()
        {
            return _dbContext.Products.ToList();
        }
        //public async Task<SubscriberResult<Product>> SubscribeToProductCreatedAsync()
        //{
        //    var product =  _dbContext.Products.OrderByDescending(p => p.Id).FirstOrDefault();

        //    return new SubscriberResult<Product>
        //    {
        //        Result = product,
        //        OnCompleted = () => Console.WriteLine("Subscription completed"),
        //        OnError = ex => Console.WriteLine($"Subscription error: {ex.Message}"),
        //        OnInitialized = () => Console.WriteLine("Subscription initialized"),
        //        OnNext = product => Console.WriteLine($"New product created: {product.Name}")
        //    };
        //}
    }
}
