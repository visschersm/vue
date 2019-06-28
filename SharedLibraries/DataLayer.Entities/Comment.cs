using System;

namespace DataLayer.Entities
{
    public class Comment
    {
        public int Id { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }

        public int? BlogId { get; set; }
        public Blog Blog { get; set; }

        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
