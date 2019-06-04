using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public int CreatedById { get; set; }
        [Required]
        public User CreatedBy { get; set; }

        [Required]
        public int PostId { get; set; }
        [Required]
        public Post Post { get; set; }
    }
}
