using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataLayer.Entities
{
    public class Post
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        [Required]
        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        [Required]
        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public ICollection<Comment> Comments { get; set; }

    }
}
