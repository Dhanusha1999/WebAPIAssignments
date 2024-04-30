using System.ComponentModel.DataAnnotations;

namespace ProductSalesWebApiAssignment.Models
{
    public class Staffs
    {
        [Key]
        public int StaffId { get; set; }    
        public string FirstName {  get; set; }
        public string LastName { get; set; }
        public string Email {  get; set; }
        public long PhoneNumber {  get; set; }
        public string Active {  get; set; }
        public Stores store {  get; set; }
        public int ManagerId {  get; set; }
    }
}
