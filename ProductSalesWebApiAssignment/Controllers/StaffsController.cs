using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffsController : ControllerBase
    {
        //dummy data
        private static readonly List<Staffs> _staff = new List<Staffs>
        {
            new Staffs
            {
                StaffId=1,
                FirstName="Kevin",
                LastName="Kevin",
                Email="kevin@gmail.com",
                PhoneNumber=9488284257,
                Active="Yes",
                store=new Stores
                {
                StoreId=1,
                StoreName="Abi",
                PhoneNumber=8220778865,
                Email="abiStore@gmail.com",
                Street="Temple Street",
                City="Trivandrum",
                State="Kerala",
                ZipCode="KL123"
                },
                ManagerId=90
            }
        };
        #region Get All Staffs

        [HttpGet]
        public IEnumerable<Staffs> GetStaff()
        {
            return _staff;
        }
        #endregion

        #region Get Staff by Id

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

        #region Create a Staff
     
        [HttpPost]
        public IActionResult CreateStaff([FromBody] Staffs staff)
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

        [HttpDelete("{id}")]
        public void DeleteStaffById(int id)
        {
            var staff = _staff.FirstOrDefault(p => p.StaffId == id);
            _staff.Remove(staff);
        }
        #endregion

        #region Update Staff by Id

        [HttpPut("{id}")]
        public IActionResult UpdateStaff(int id, [FromBody] Staffs updatedStaff)
        {
            var updateStaff = _staff.FirstOrDefault(p => p.StaffId == id);
            updateStaff.FirstName = updatedStaff.FirstName;
            updateStaff.LastName= updatedStaff.LastName;
            updateStaff.PhoneNumber = updatedStaff.PhoneNumber;
            updateStaff.Email= updatedStaff.Email;
            updateStaff.Active= updatedStaff.Active;
            updateStaff.store= updatedStaff.store;
            updateStaff.ManagerId= updatedStaff.ManagerId;
            return Ok(updateStaff);
        }

        #endregion
    }
}
