using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TheBakery.Models
{
    public class Product
    {
        public int id { get; set; }
        public String name { get; set; }
        public float price { get; set; }
        public int inStorage { get; set; }
    }
}