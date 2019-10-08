using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.DbModel
{
    public class Blog
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }

        public int CreatedById { get; set; }
        public User CreatedBy { get; set; }

        public DateTime CreatedDate { get; set; }
    }
}
