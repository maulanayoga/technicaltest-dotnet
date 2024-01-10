
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;
using TestBackend.Context;
using TestBackend.Models;
using TestBackend.Repository.Interface;
using TestBackend.ViewModels;

namespace TestBackend.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyContext context;

        public ProductRepository(MyContext context)
        {
            this.context = context;
        }

        public int Insert(Product product)
        {
            context.Products.Add(product);

            var result = context.SaveChanges();
            return result;
        }
        public IEnumerable<Product> GetData()
        {
            return context.Products.ToList();
        }

        public Product Get(int ProductId)
        {
            return context.Products.Find(ProductId);
        }
        public int Update(Product product)
        {
            context.Entry(product).State = EntityState.Modified;
            var result = context.SaveChanges() ;
            return result;
        }
        public int Delete(int ProductId)
        {
            var entity = context.Products.Find(ProductId);
            context.Remove(entity);
            var result = context.SaveChanges();
            return result;
        }

    }
}
