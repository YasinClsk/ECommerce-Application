using ETicaretAPI.Application.Abstractions;
using ETicatetAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistance.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts()
            => new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Product2", Price = 101, Stock = 11 },
                new() { Id = Guid.NewGuid(), Name = "Product3", Price = 102, Stock = 12 },
                new() { Id = Guid.NewGuid(), Name = "Product1", Price = 103, Stock = 13 },
                new() { Id = Guid.NewGuid(), Name = "Product4", Price = 104, Stock = 14 },
            };
        
    }
}
