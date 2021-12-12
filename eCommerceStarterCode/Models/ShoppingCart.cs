using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace eCommerceStarterCode.Models
{
    public class ShoppingCart
    {
        public int ShoppingCartId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
