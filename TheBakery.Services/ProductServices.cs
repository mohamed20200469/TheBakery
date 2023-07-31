using ITheBakery.Services;
using ITheBakery.DAL;
using Data.SQL;

namespace TheBakery.Services
{
    public class ProductServices : IProductServices
    {
        private readonly IProductDAL _productDAL;

        public ProductServices(IProductDAL productsDAL)
        {
            _productDAL = productsDAL;
        }

        public bool AddProduct(string name, float price, int stock)
        {
            return _productDAL.AddProduct(name, price, stock);
        }

        public IEnumerable<ProductEntity> GetProducts()
        {
            return _productDAL.GetProducts();
        }

        public bool DeleteProduct(int id)
        {
            return _productDAL.DeleteProduct(id);
        }

        public bool ChangePrice(int id, float price)
        {
            return _productDAL.ChangePrice(id, price);
        }

        public ProductEntity GetProductById(int id)
        {
            return _productDAL.GetProduct(id);
        }

        public bool UpdateStock(int id, int stock)
        {
            return _productDAL.UpdateStock(id, stock);   
        }
    }
}