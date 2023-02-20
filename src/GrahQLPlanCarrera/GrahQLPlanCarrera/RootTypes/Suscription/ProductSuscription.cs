using GrahQLPlanCarrera.Domain.Interfaces.Models;
using GrahQLPlanCarrera.Domain.Models;
using GraphQL.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Reactive.Linq;

namespace GrahQLPlanCarrera.RootTypes.Suscription
{
    public class ProductSuscription: ObjectGraphType
    {
        private readonly IProduct productServices;
        public ProductSuscription(IProduct productServices)
        {
            this.productServices = productServices;
        }
        public IObservable<Product> OnProductCreated()
        {
            return Observable.FromEventPattern<Product>(
                handler => ProductCreated += handler,
                handler => ProductCreated -= handler)
                .Select(x => x.EventArgs);
        }

        public event EventHandler<Product> ProductCreated;


    }
}
