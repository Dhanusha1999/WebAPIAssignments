using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductSalesWebApiAssignment.Models;

namespace ProductSalesWebApiAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController : ControllerBase
    {
        //dummy data
        private static readonly List<Stores> _store = new List<Stores>
        {
            new Stores
            {
                StoreId=1,
                StoreName="Abi",
                PhoneNumber=8220778865,
                Email="abiStore@gmail.com",
                Street="Temple Street",
                City="Trivandrum",
                State="Kerala",
                ZipCode="KL123"
            }
        };
        #region Get All Stores

        [HttpGet]
        public IEnumerable<Stores> GetStore()
        {
            return _store;
        }
        #endregion

        #region Get Store by Id

        [HttpGet("{id}")]
        public IActionResult GetStoreById(int id)
        {
            var store = _store.FirstOrDefault(p => p.StoreId == id);
            if (store == null)
            {
                return NotFound();
            }
            return Ok(store);
        }
        #endregion

        #region Create a Store
       
        [HttpPost]
        public IActionResult CreateStore([FromBody] Stores store)
        {
            if (ModelState.IsValid)
            {
                store.StoreId = _store.Count + 1;
                _store.Add(store);
                return Ok(_store);
            }
            return BadRequest(ModelState);
        }
        #endregion

        #region Delete Store by Id

        [HttpDelete("{id}")]
        public void DeleteStoreById(int id)
        {
            var store = _store.FirstOrDefault(p => p.StoreId == id);
            _store.Remove(store);
        }
        #endregion

        #region Update Store by Id

        [HttpPut("{id}")]
        public IActionResult UpdateStore(int id, [FromBody] Stores updatedStore)
        {
            var updateStore = _store.FirstOrDefault(p => p.StoreId == id);
            updateStore.StoreName = updatedStore.StoreName;
            updateStore.PhoneNumber = updatedStore.PhoneNumber;
            updateStore.Email = updatedStore.Email;
            updateStore.Street = updatedStore.Street;
            updateStore.City = updatedStore.City;
            updateStore.State = updatedStore.State;
            updateStore.ZipCode = updatedStore.ZipCode;
            return Ok(updateStore);
        }

        #endregion
    }
}
