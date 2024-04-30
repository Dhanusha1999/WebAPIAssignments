using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        //dummy data
        private static readonly List<Orders> _order = new List<Orders>
        {
            new Orders
            {
                OrderId=1,
                customer=new Customers
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
                },
                OrderStatus="Completed",
                OrderDate=Convert.ToDateTime("05/20/2024"),
                RequiredDate=Convert.ToDateTime("05/20/2024"),
                ShippedDate=Convert.ToDateTime("05/20/2024"),
                staff=new Staffs
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
            }
        };
        #region Get All Orders

        [HttpGet]
        public IEnumerable<Orders> GetOrder()
        {
            return _order;
        }
        #endregion

        #region Get Order by Id

        [HttpGet("{id}")]
        public IActionResult GetorderById(int id)
        {
            var order = _order.FirstOrDefault(p => p.OrderId== id);
            if (order == null)
            {
                return NotFound();
            }
            return Ok(order);
        }
        #endregion

        #region Create a Order
        //POST : api/customers
        [HttpPost]
        public IActionResult CreateOrder([FromBody] Orders order)
        {
            if (ModelState.IsValid)
            {
                order.OrderId = _order.Count + 1;
                _order.Add(order);
                return Ok(_order);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete Order by Id

        [HttpDelete("{id}")]
        public void DeleteOrderById(int id)
        {
            var order = _order.FirstOrDefault(p => p.OrderId == id);
            _order.Remove(order);
        }
        #endregion

        #region Update Order by Id

        [HttpPut("{id}")]
        public IActionResult UpdateOrder(int id, [FromBody] Orders updatedOrder)
        {
            var updateOrder = _order.FirstOrDefault(p => p.OrderId == id);
            updateOrder.customer= updatedOrder.customer;
            updateOrder.OrderStatus= updatedOrder.OrderStatus;
            updateOrder.OrderDate= updatedOrder.OrderDate;
            updateOrder.RequiredDate= updatedOrder.RequiredDate;
            updateOrder.ShippedDate= updatedOrder.ShippedDate;
            updateOrder.staff = updatedOrder.staff;
            return Ok(updateOrder);
        }

        #endregion
    }
}
