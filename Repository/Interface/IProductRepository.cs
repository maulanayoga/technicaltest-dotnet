using TestBackend.Models;
using TestBackend.ViewModels;

namespace TestBackend.Repository.Interface
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetData();
        Product Get(int ProductId);
        int Insert(Product product);
        //int Insert(Employee employee);
        int Update(Product product);
        int Delete(int ProductId);
    }
}
