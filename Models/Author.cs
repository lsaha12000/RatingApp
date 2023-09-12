using System.ComponentModel.DataAnnotations;

namespace RatingApp.Models
{
    public class Author
    {
        [Key]
        public string emailId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public List<Book>? books { get; set; }
    }
}
