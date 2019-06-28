using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class Post
    {
        public int Id { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
