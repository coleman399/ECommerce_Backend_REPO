using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

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
        public Nullable <int> ReviewId { get; set; }
        public Review Review { get; set; }
        
        [ForeignKey("Category")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
