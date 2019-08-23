using System;
using System.ComponentModel.DataAnnotations;

namespace DbModel
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
