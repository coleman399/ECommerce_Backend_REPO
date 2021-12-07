using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eCommerceStarterCode.Models
{
    public class Review
    {
        [Key]
        public int ReviewId { get; set; }
        public string ReviewText { get; set; }
        public int ReviewRating { get; set; }
        [ForeignKey("User")]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}
