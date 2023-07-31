using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.SQL
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string ordererName { get; set; }
        [Required]
        [ForeignKey("Product")]
        public int productId { get; set; }
        public ProductEntity Product { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public bool delivered { get; set; } = false;
    }
}
