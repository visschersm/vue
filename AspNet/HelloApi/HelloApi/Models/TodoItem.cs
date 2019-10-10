using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace HelloApi.Models
{
    public class TodoItem
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        [DefaultValue(false)]
        public bool IsComplete { get; set; }
        [DefaultValue(null)]
        public DateTime? CompletedDate { get; set; }
    }
}
