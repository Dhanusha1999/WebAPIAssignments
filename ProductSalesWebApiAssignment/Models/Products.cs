using System.ComponentModel.DataAnnotations;

namespace ProductSalesWebApiAssignment.Models
{
    public class Products
    {
        [Key]
        public int ProductId {  get; set; }
        public string ProductName { get; set; }
        public Brands brand {  get; set; } 
        public Categories category { get; set; }
        public int ModelYear {  get; set; }
        public decimal ListPrice {  get; set; }
    }
}
