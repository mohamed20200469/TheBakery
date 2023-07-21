using ITheBakery.DAL;
using ITheBakery.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBakery.Entities;

namespace TheBakery.Services
{
    public class OrderServices : IOrderServices
    {
        private readonly IOrderDAL _orderDAL;
        public OrderServices(IOrderDAL orderDAL)
        {
            _orderDAL = orderDAL;
        }

        public bool AddOrder(string name, int productId, int amount)
        {
           return _orderDAL.AddOrder(name, productId, amount);
        }

        public bool DeleteOrder(int id)
        {
            return _orderDAL.DeleteOrder(id);
        }

        public OrderEntity? GetOrderById(int id)
        {
            return _orderDAL.GetOrderById(id);
        }

        public IEnumerable<OrderEntity> GetOrders()
        {
            return _orderDAL.GetOrders();
        }

        public bool UpdateDeliveryState(int id, bool deliveryState)
        {
            return _orderDAL.UpdateDeliveryState(id, deliveryState);
        }
    }
}
