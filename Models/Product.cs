using System.ComponentModel.DataAnnotations;

namespace TestBackend.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        
    }
}
