using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        [ForeignKey("Plant")]
        public int PlantId { get; set; }
        public Plant Plant { get; set; }
    }
}
