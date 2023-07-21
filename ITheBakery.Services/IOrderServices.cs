using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheBakery.Entities;

namespace ITheBakery.Services
{
    public interface IOrderServices
    {
        public IEnumerable<OrderEntity> GetOrders();
        public OrderEntity? GetOrderById(int id);
        public bool UpdateDeliveryState(int id, bool deliveryState);
        public bool DeleteOrder(int id);
        public bool AddOrder(string name, int productId, int amount);
    }
}
