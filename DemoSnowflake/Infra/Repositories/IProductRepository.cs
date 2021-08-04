using DemoSnowflake.Domain.Entities;
using System;
using System.Collections.Generic;

namespace DemoSnowflake.Infra.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> Get();
        Product GetById(Guid id);
        Product Add(Product product);
        Product Update(Product product);
        bool Delete(Product product);
    }
}
