using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
