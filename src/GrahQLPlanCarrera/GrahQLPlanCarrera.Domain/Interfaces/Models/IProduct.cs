using GrahQLPlanCarrera.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrahQLPlanCarrera.Domain.Interfaces.Models
{
    public interface IProduct
    {
        List<Product> GetAllProducts();
        Product AddProduct(Product product);
        Product UpdateProduct(int id,Product product);
        void DeleteProduct(int id);
        Product GetProductById(int id);
    }
}
