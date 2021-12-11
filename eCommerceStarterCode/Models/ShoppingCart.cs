using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingCartId { get; set; }
        [ForeignKey("Product")]
        public Nullable <int> ProductId { get; set; }
        public Product Product { get; set; }
    }
}
