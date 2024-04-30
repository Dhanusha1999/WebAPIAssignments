using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderItemsController : ControllerBase
    {
        //dummy data
        private static readonly List<OrderItems> _orderItem = new List<OrderItems>
        {
            new OrderItems
            {
                ItemId=1,
                order=new Orders
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
                },
                product=new Products
                {
                ProductId=1,
                ProductName="Dark Fantacy",
                    brand=new Brands
                    {
                         BrandId=1,
                         BrandName="Nescafe"
                    },
                    category=new Categories
                    {
                         CategoryId=1,
                         CategoryName="Food"
                    },
                ModelYear=2017,
                ListPrice=120
                },
                Quantity=100,
                ListPrice=200,
                Discount=20               
            }
        };
        #region Get All Orderd Items

        [HttpGet]
        public IEnumerable<OrderItems> GetOrderItem()
        {
            return _orderItem;
        }
        #endregion

        #region Get Order Item by Id

        [HttpGet("{id}")]
        public IActionResult GetOrderItemById(int id)
        {
            var orderItem = _orderItem.FirstOrDefault(p => p.ItemId == id);
            if (orderItem == null)
            {
                return NotFound();
            }
            return Ok(orderItem);
        }
        #endregion

        #region Create a OrderItem
        
        [HttpPost]
        public IActionResult CreateOrderItem([FromBody] OrderItems orderItem)
        {
            if (ModelState.IsValid)
            {
                orderItem.ItemId = _orderItem.Count + 1;
                _orderItem.Add(orderItem);
                return Ok(_orderItem);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete OrderItem by Id

        [HttpDelete("{id}")]
        public void DeleteOrderItemById(int id)
        {
            var orderItem = _orderItem.FirstOrDefault(p => p.ItemId == id);
            _orderItem.Remove(orderItem);
        }
        #endregion

        #region Update OrderItem by Id

        [HttpPut("{id}")]
        public IActionResult UpdateOrderItem(int id, [FromBody] OrderItems updatedOrderItem)
        {
            var updateOrderItem = _orderItem.FirstOrDefault(p => p.ItemId == id);
            updateOrderItem.order = updatedOrderItem.order;
            updateOrderItem.product= updatedOrderItem.product;
            updateOrderItem.Quantity= updatedOrderItem.Quantity;
            updateOrderItem.ListPrice= updatedOrderItem.ListPrice;
            updateOrderItem.Discount= updatedOrderItem.Discount;
            return Ok(updateOrderItem);
        }

        #endregion
    }
}
