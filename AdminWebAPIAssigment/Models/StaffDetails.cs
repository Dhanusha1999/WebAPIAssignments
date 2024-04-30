using System.ComponentModel.DataAnnotations.Schema;

namespace AdminWebAPIAssigment.Models
{
    public class StaffDetails
    {
        public int StaffId {  get; set; }
        public string Name {  get; set; }
        public DateTime DateOfBirth { get; set; }
        public long PhoneNumber {  get; set; }
        public string Address {  get; set; }
        public string Email {  get; set; }
        public DateTime DateOfJoining { get; set; }
        public Designation designation { get; set; }

    }
}
