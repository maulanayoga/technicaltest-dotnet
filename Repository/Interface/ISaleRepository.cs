using TestBackend.Models;
using TestBackend.ViewModels;

namespace TestBackend.Repository.Interface
{
    public interface ISaleRepository
    {
        IEnumerable<Sale> GetData();
        //public EmployeeVM GetData(string NIK);
        Sale Get(int SaleId);
        int Insert(SaleVM salevm);
        //int Insert(Employee employee);
        int Update(SaleVM salevm);
        int Delete(int SaleId);
    }
}
