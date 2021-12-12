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

        public string Category { get; set; }
        
        public int Rating { get; set; }
        
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }
    }
}
