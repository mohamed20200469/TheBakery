using Data.SQL;

namespace ITheBakery.Services
{
    public interface IProductServices
    {
        public bool AddProduct(string name, float price, int stock);
        public IEnumerable<ProductEntity> GetProducts();
        public bool DeleteProduct(int id);
        public ProductEntity GetProductById(int id);
        public bool ChangePrice(int id, float price);
        public bool UpdateStock(int id, int stock);
    }
}