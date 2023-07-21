using TheBakery.Models;
using ITheBakery.DAL;
using Data.SQL;
using TheBakery.Entities;

namespace TheBakery.DAL
{
    public class ProductDAL : IProductDAL
    {
        private readonly ProductDbContext _db;
        public ProductDAL(ProductDbContext db)
        {
            _db = db;
        }

        public ProductEntity CreateProduct(string name, float price, int stock)
        {
            ProductEntity product = new();
            product.price = price;
            product.name = name;
            product.inStorage = stock;
            return product;
        }
        public bool AddProduct(string name, float price, int stock)
        {
            if (price > 0)
            {
                _db.Products.Add(CreateProduct(name, price, stock));
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public ProductEntity GetProduct(int id)
        {
            ProductEntity product;
            foreach (ProductEntity product1 in _db.Products)
            {
                if (product1.id == id)
                {
                    product = product1;
                    return product;
                }
            }
            return null;
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            return _db.Products;
        }

        public bool DeleteProduct(int id)
        {
            ProductEntity product = _db.Products.Find(id);
            if (product.id > 0)
            {
                _db.Products.Remove(product);
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ChangePrice(int id, float price)
        {
            ProductEntity product = _db.Products.Find(id);
            if (product != null && product.id > 0)
            {
                product.price = price;
                _db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UpdateStock(int id, int stock)
        {
            ProductEntity product = _db.Products.Find(id);
            if (product != null && product.id > 0)
            {
                product.inStorage = stock;
                _db.SaveChanges();
                return true;
            }
            return false;
        }
    }
}