using DataLayer.Entities.Interfaces;
using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Entities
{
    public class ApplicationUser : IdentityUser<Guid>, ISoftDeletable, IEntity<Guid>
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; } = null!;

        public string? MiddleName { get; set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; set; } = null!;

        [Required]
        public DateTime CreateDate { get; set; }

        public string FullName => $"{FirstName} {MiddleName ?? string.Empty} {LastName}";

        public DateTime? DeletedOn { get; set; }

        public Guid UserId { get; set; }

        object IEntity.Id => Id;
    }
}
