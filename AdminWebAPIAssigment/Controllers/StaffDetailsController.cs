using AdminWebAPIAssigment.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdminWebAPIAssigment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffDetailsController : ControllerBase
    {
        //dummy data
        private static readonly List<StaffDetails> _staff = new List<StaffDetails>
        {
            new StaffDetails 
            { StaffId = 1,
                Name="Anandhu",
                DateOfBirth=Convert.ToDateTime("05/21/2000"),
                PhoneNumber=Convert.ToInt64(9345552871),
                Address="Nagercoil",
                Email="Mandy@gmail.com",
                DateOfJoining=Convert.ToDateTime("05/21/2024"),
                designation=new Designation
                {
                    DesignationId=1,
                    DesignationName="Admin"
                }

            }
        };
        #region Get All Staff Details
        //Get products (endpoint: api/Products)
        [HttpGet]
        public IEnumerable<StaffDetails> GetStaffs()
        {
            return _staff;
        }
        #endregion

        #region Get Staff by Id
        //GET : api/products/{id}
        [HttpGet("{id}")]
        public IActionResult GetStaffById(int id)
        {
            var staff = _staff.FirstOrDefault(p => p.StaffId == id);
            if (staff == null)
            {
                return NotFound();
            }
            return Ok(staff);
        }
        #endregion

        #region Create a Staff Details
        //POST : api/products
        [HttpPost]
        public IActionResult CreateStaff([FromBody] StaffDetails staff)
        {
            if (ModelState.IsValid)
            {
                staff.StaffId = _staff.Count + 1;
                _staff.Add(staff);
                return Ok(_staff);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete Staff by Id
        //GET : api/products/{id}
        [HttpDelete("{id}")]
        public void DeleteStaffById(int id)
        {
            var staff = _staff.FirstOrDefault(p => p.StaffId == id);
            _staff.Remove(staff);
        }
        #endregion

        #region Update Staff by Id
        //GET : api/products/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, [FromBody] StaffDetails updatedStaff)
        {
            var updateStaff = _staff.FirstOrDefault(p => p.StaffId == id);
            updateStaff.Name = updatedStaff.Name;
            updateStaff.DateOfBirth = updatedStaff.DateOfBirth;
            updateStaff.PhoneNumber = updatedStaff.PhoneNumber;
            updateStaff.Address = updatedStaff.Address;
            updateStaff.Email = updatedStaff.Email;
            updateStaff.DateOfJoining = updatedStaff.DateOfJoining;
            updateStaff.designation = updatedStaff.designation;
            return Ok(updateStaff);
        }

        #endregion
    }
}
