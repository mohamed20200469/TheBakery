using Data.SQL;

namespace ITheBakery.DAL
{
    public interface IProductDAL
    {
        public bool UpdateStock(int id, int stock);
        public ProductEntity CreateProduct(string name, float price, int stock);
        public bool AddProduct(string name, float price, int stock);
        public ProductEntity GetProduct(int id);
        public IEnumerable<ProductEntity> GetProducts();
        public bool DeleteProduct(int id);
        public bool ChangePrice(int id, float price);

    }
}