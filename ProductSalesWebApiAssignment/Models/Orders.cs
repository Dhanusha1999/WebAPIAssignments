using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProductSalesWebApiAssignment.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }   
        [Required]
        public string OrderStatus {  get; set; }
        [Required]
        public DateTime OrderDate {  get; set; }
        [Required]
        public DateTime RequiredDate { get; set;}
        [Required]
        public DateTime ShippedDate { get; set;}
        public Staffs staff { get; set; }
        public Customers customer { get; set; }
     
    }
}
