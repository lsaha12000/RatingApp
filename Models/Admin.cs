using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace RatingApp.Models
{
    public class Admin
    {
        [Key]
        [DataType(DataType.EmailAddress)]
        [Remote(action: "AdminExist",controller:"Admin")]
        public string emailId { get; set; }
        [Required,StringLength(15,MinimumLength =5,ErrorMessage ="Password should be minimum of 6 length")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}
