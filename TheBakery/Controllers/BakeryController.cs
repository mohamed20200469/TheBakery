using ITheBakery.Services;
using Microsoft.AspNetCore.Mvc;
using TheBakery.Entities;

namespace TheBakery.Controllers
{
    [ApiController]
    public class TheBakeryController : ControllerBase
    {
        private readonly IProductServices _productServices;
        private readonly IOrderServices _orderServices;
        public TheBakeryController(IProductServices productServices, IOrderServices orderServices)
        {
            _productServices = productServices;
            _orderServices = orderServices;
        }
        [HttpPost("AddProduct")]
        public ActionResult<ProductEntity> Post(string name, float price, int stock)
        {
            if (_productServices.AddProduct(name, price, stock))
            {
                return Ok("Product added!");
            }
            return BadRequest();
        }

        [HttpGet("GetProductById")]
        public ActionResult<ProductEntity> Get(int id)
        {
            ProductEntity product = _productServices.GetProductById(id);
            if (product != null)
            {
                return Ok(product);
            }
            return NotFound();
        }

        [HttpGet("GetProducts")]
        public ActionResult<IEnumerable<ProductEntity>> Get()
        {
            return Ok(_productServices.GetProducts());
        }

        [HttpDelete("DeleteProduct")]
        public ActionResult Delete(int id)
        {
            if (_productServices.DeleteProduct(id))
            {
                return Ok("Product removed from database!");
            }
            return NotFound();
        }

        [HttpPatch("ChangePrice")]
        public ActionResult Patch(int id, float price)
        {
            if (_productServices.ChangePrice(id, price))
            {
                return Ok("Product price changed!");
            }
            return BadRequest();
        }
        [HttpPatch("AddStock")]
        public ActionResult Patch(int id, int stock)
        {
            if (_productServices.UpdateStock(id, stock))
            {
                return Ok("Stock updated!");
            }
            return BadRequest();
        }
        [HttpPost("CreateOrder")]
        public ActionResult Post( string name,int productId,int amount)
        {
            if(_productServices.GetProductById(productId) != null && _orderServices.AddOrder(name, productId, amount))
            {
                return Ok("Order created succesfully!");
            }
            return BadRequest();
        }
        [HttpGet("GetAllOrders")]
        public IEnumerable<OrderEntity> GetAllOrders()
        {
            return _orderServices.GetOrders();
        }
        [HttpGet("GetOrderById")]
        public ActionResult<OrderEntity?> GetOrder(int id)
        {
            OrderEntity order = _orderServices.GetOrderById(id);
            if (order != null)
            {
                return Ok(order);
            }
            return NotFound(null);
        }
        [HttpPatch("FillOrder")]
        public ActionResult FillOrderById(int id)
        {
            OrderEntity order = _orderServices.GetOrderById(id);
            ProductEntity product = _productServices.GetProductById(order.productId);
            if (order.amount <= product.inStorage)
            {
                _productServices.UpdateStock(id, (product.inStorage - order.amount));
                _orderServices.UpdateDeliveryState(id, true);
                return Ok("Order filled!");
            }
            return BadRequest();
        }
        [HttpDelete("DeleteOrder")]
        public ActionResult DeleteOrder(int id)
        {
            if (_orderServices.DeleteOrder(id))
            {
                return Ok("Order removed from database!");
            }
            return BadRequest();
        }
    }
}