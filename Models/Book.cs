using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CLDV6211_ICE_Task_1.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string? Title { get; set; }

        [Required]
        public string? Author { get; set; }

        [StringLength(200, MinimumLength = 1)]
        [Required]
        public string? Description { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }

        [RegularExpression(@"^\d+(\.\d+)?$")]
        [Required]
        public string? Price { get; set; }

        [Required]
        public string? Genre { get; set; }

        [StringLength(10)]
        [Required]
        public string? Rating { get; set; }

        public bool IsFavorited { get; set; } // New property for favorited status
    }
}
