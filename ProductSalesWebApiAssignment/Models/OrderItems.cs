using System.ComponentModel.DataAnnotations;

namespace ProductSalesWebApiAssignment.Models
{
    public class OrderItems
    {
        public Orders order { get;set; }
        [Key]
        public int ItemId {  get; set; }
        public Products product { get; set; }
        public int Quantity {  get; set; }
        public decimal ListPrice {  get; set; }
        public decimal Discount {  get; set; }
    }
}
