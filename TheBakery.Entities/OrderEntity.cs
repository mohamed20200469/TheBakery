using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheBakery.Entities
{
    public class OrderEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string ordererName { get; set; }
        [Required]
        [ForeignKey("ProductEntity")]
        public int productId { get; set; }
        [Required]
        public int amount { get; set; }
        [Required]
        public bool delivered { get; set; } = false;
    }
}
