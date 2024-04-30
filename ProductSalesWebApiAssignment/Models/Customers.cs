using System.ComponentModel.DataAnnotations;

namespace ProductSalesWebApiAssignment.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId {  get; set; }
        [Required]
        public string FirstName {  get; set; }
        [Required]
        public string LastNamae { get; set; }
        [Required]
        public long PhoneNumber {  get; set; }
        [Required]
        public string Email {  get; set; }
        [Required]
        public string Street {  get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State {  get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
