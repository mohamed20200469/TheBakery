using Data.SQL;
using ITheBakery.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBakery.DAL
{
    public class OrderDAL : IOrderDAL
    {
        private readonly AppDbContext _db;
        public OrderDAL(AppDbContext db)
        {
            _db = db;
        }

        public bool AddOrder(string name, int productId, int amount)
        {
            if(amount > 0 && productId > 0)
            {
                _db.Add(CreateOrder( name, productId, amount));
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public OrderEntity CreateOrder(string name, int productId, int amount)
        {
            OrderEntity orderEntity = new OrderEntity();
            orderEntity.amount = amount;
            orderEntity.ordererName = name;
            orderEntity.productId = productId;
            return orderEntity;
        }

        public bool DeleteOrder(int id)
        {
            OrderEntity order = _db.orders.Find(id);
            if (order != null)
            {
                _db.orders.Remove(order);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public OrderEntity? GetOrderById(int id)
        {
            OrderEntity order = _db.orders.Find(id);
            if (order != null)
            {
                return order;
            }
            return null;
        }

        public IEnumerable<OrderEntity> GetOrders()
        {
            return _db.orders;
        }

        public bool UpdateDeliveryState(int id, bool deliveryState)
        {
            OrderEntity order = _db.orders.Find(id);
            if (order != null)
            {
                order.delivered = deliveryState;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
