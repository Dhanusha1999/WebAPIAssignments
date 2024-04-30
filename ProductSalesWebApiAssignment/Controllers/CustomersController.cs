using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        //dummy data
        private static readonly List<Customers> _customer = new List<Customers>
        {
            new Customers
            { 
                CustomerId=1,
                FirstName="Drishya",
                LastNamae="Prakash",
                PhoneNumber=9345552871,
                Email="drish@gmail.com",
                Street="Temple Street",
                City="Trivandrum",
                State="Kerala",
                ZipCode="KL123"
            }
        };
        #region Get All Customer Details
        // (endpoint: api/customers)
        [HttpGet]
        public IEnumerable<Customers> GetCustomers()
        {
            return _customer;
        }
        #endregion

        #region Get Customer by Id
        //GET : api/customers/{id}
        [HttpGet("{id}")]
        public IActionResult GetCustomerById(int id)
        {
            var customer = _customer.FirstOrDefault(p => p.CustomerId == id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }
        #endregion

        #region Create a Customer Details
        //POST : api/customers
        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customers customer)
        {
            if (ModelState.IsValid)
            {
                customer.CustomerId = _customer.Count + 1;
                _customer.Add(customer);
                return Ok(_customer);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete Customer by Id
        //GET : api/customers/{id}
        [HttpDelete("{id}")]
        public void DeleteCustomerById(int id)
        {
            var customer = _customer.FirstOrDefault(p => p.CustomerId == id);
            _customer.Remove(customer);
        }
        #endregion

        #region Update Customer by Id
        //GET : api/cutomer/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateCustomer(int id, [FromBody] Customers updatedCustomer)
        {
            var updateCustomer = _customer.FirstOrDefault(p => p.CustomerId== id);
            updateCustomer.FirstName = updatedCustomer.FirstName;
            updateCustomer.LastNamae=updatedCustomer.LastNamae;
            updateCustomer.PhoneNumber = updatedCustomer.PhoneNumber;
            updateCustomer.Email=updatedCustomer.Email;
            updateCustomer.Street=updatedCustomer.Street;
            updateCustomer.City=updatedCustomer.City;
            updateCustomer.State=updatedCustomer.State;
            updateCustomer.ZipCode=updatedCustomer.ZipCode;           
            return Ok(updateCustomer);
        }

        #endregion
    }
}
