using System.ComponentModel.DataAnnotations;

namespace webAPIStarter.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set;}
        [Required]
        public string Author { get; set; }
        [Required]
        public string Content { get; set; }
    }
}