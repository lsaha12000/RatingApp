using System.ComponentModel.DataAnnotations;

namespace RatingApp.Models
{
    public class Reader
    {
        [Key]
        public string emailId { get; set; }
        [Required]
        [StringLength(15,MinimumLength =5)]
        [DataType(DataType.Password)]
        public string password {  get; set; }
        [Required]
        public string Name { get; set; }
    }
}
