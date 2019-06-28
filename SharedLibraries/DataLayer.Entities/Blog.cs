using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
