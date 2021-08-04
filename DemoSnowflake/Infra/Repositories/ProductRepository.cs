using DemoSnowflake.Domain.Entities;
using DemoSnowflake.Infra.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace DemoSnowflake.Infra.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ISessionDataContext _sessionDataContext;
        
        public ProductRepository(ISessionDataContext sessionDataContext)
        {
            _sessionDataContext = sessionDataContext;
        }

        public IEnumerable<Product> Get()
        {
            StringBuilder sql = new StringBuilder();

            var result = _sessionDataContext.Query<Product>(sql.ToString(), new { });

            return result;
        }

        public Product GetById(Guid id)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine("SELECT Id, Name ");
            sql.AppendLine($"FROM tableName ");
            sql.AppendLine("WHERE Id = @id ");

            var result = _sessionDataContext.QuerySingleOrDefault<Product>(sql.ToString(), new { Id = id });
            if (result != null)
                return result;

            return new Product();
        }

        public Product Update(Product product)
        {
            throw new NotImplementedException();
        }

        public Product Add(Product product)
        {
            StringBuilder sql = new StringBuilder();

            sql.AppendLine($"INSERT INTO Product (Id, Name) ");
            sql.AppendLine("VALUES (@Id, @Name)");

            _sessionDataContext.Execute(
                sql.ToString(),
                new { Id = product.Id, Name = product.Name}
                );

            var result = GetById(product.Id);
            if (result != null)
                return result;

            return new Product();
        }

        public bool Delete(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
