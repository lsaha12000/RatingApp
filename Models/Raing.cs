using System.ComponentModel.DataAnnotations;

namespace RatingApp.Models
{
    public class Raing
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(0.0,10.0,ErrorMessage ="Raing should be between 0 to 10")]
        public float raing { get; set; }
        [Required]
        public string BookName { get; set; }
        [Required]
        public string AuthorName { get; set; }
        public virtual Book? book { get; set; }
        public virtual Reader? reader { get; set; }
        
    }
}
