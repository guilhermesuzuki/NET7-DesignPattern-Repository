using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Models
{
    /// <summary>
    /// Person class (maps to a table called People).
    /// </summary>
    [Table("People")]
    [Index(nameof(FirstName), nameof(LastName), IsUnique = true, Name = "IX_People_1")]
    public class Person: 
        Interfaces.IId,
        Interfaces.IName,
        Interfaces.IDeleted
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [NotMapped]
        public bool Deleted { get; set; }
    }
}