using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Plant
    {
        [Key]
        public int PlantId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        [ForeignKey("Review")]
        public string ReviewId { get; set; }
        public User Review { get; set; }
        [ForeignKey("Category")]
        public string CategoryId { get; set; }
        public Category Category { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
