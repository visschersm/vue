using System;
using System.Collections.Generic;

namespace DataLayer.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName => $"{FirstName} {LastName}";

        public DateTime CreatedDate { get; set; }
        public ICollection<Blog> Blogs { get; set; }
        public ICollection<Post> Posts { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
