using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using TestBackend.Context;
using TestBackend.Models;
using TestBackend.Repository.Interface;
using TestBackend.ViewModels;

namespace TestBackend.Repository
{
    public class SaleRepository : ISaleRepository
    {
        private readonly MyContext context;

        public SaleRepository(MyContext context)
        {
            this.context = context;
        }

        public int Insert(SaleVM salevm)
        {

            var sale = new Sale
            {
                SaleId = salevm.SaleId,
                SaleDate= salevm.SaleDate,
                Quantity= salevm.Quantity,
                ProductId= salevm.ProductId,
            };
            context.Sales.Add(sale);

            return context.SaveChanges();
        }
        public IEnumerable<Sale> GetData()
        {
            return context.Sales.Include(x => x.Product).ToList();
        }
        public Sale Get(int SaleId)
        {
            return context.Sales.Include(x => x.Product).SingleOrDefault(x => x.SaleId == SaleId);
        }

        public int Update(SaleVM salevm)
        {
            var sle = context.Sales.FirstOrDefault(sle => sle.SaleId == salevm.SaleId);

            sle.SaleId = salevm.SaleId;
            sle.SaleDate = salevm.SaleDate;
            sle.Quantity = salevm.Quantity;
            sle.ProductId = salevm.ProductId;
            context.Entry(sle).State = EntityState.Modified;
            var save = context.SaveChanges();
            return save;
        }
        public int Delete(int SaleId)
        {
            var entity = context.Sales.Find(SaleId);
            context.Remove(entity);
            var result = context.SaveChanges();
            return result;
        }

    }

}
