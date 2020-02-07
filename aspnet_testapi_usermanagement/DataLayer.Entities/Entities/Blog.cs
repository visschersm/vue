using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Blog : BaseEntity<Guid>
    {
        [Required]
        public string Title { get; set; } = null!;
    }
}
