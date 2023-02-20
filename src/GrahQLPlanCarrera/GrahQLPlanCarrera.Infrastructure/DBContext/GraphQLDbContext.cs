using GrahQLPlanCarrera.Domain.Interfaces;
using GrahQLPlanCarrera.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace GrahQLPlanCarrera.Infrastructure.DBContext
{
    public class GraphQLDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public GraphQLDbContext(DbContextOptions<GraphQLDbContext> options):base(options)
        {

        }
    }
}
