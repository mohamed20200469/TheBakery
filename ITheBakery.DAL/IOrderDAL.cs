using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.SQL;

namespace ITheBakery.DAL
{
    public interface IOrderDAL
    {
        public IEnumerable<OrderEntity> GetOrders();
        public OrderEntity? GetOrderById(int id);
        public bool UpdateDeliveryState(int id, bool  deliveryState);
        public bool DeleteOrder(int id);
        public OrderEntity CreateOrder(string name, int productId, int amount);
        public bool AddOrder(string name, int productId, int amount);
    }
}
