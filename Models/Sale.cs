using System.ComponentModel.DataAnnotations;

namespace TestBackend.Models
{
    public class Sale
    {
        [Key]
        public int SaleId { get; set; }
        public DateTime SaleDate { get; set; }
        public int Quantity { get; set; } 
        public int ProductId { get; set; }  
        public Product Product { get; set; }
       
    }
}
