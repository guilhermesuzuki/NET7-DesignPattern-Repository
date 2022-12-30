using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    [Table("Cars")]
    [Index(nameof(Make), nameof(Model), nameof(LicensePlate), nameof(PersonId), IsUnique = true, Name = "IX_Cars_1")]
    public class Car: 
        Interfaces.IId,
        Interfaces.IDeleted
    {
        [Key]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Make of the Car.
        /// </summary>
        [Required]
        [StringLength(50)]
        public string Make { get; set; } = string.Empty;

        /// <summary>
        /// Model of the Car.
        /// </summary>
        [Required]
        [StringLength(100)]
        public string Model { get; set; } = string.Empty;

        /// <summary>
        /// Plate Number of the Car.
        /// </summary>
        [Required]
        [StringLength(25)]
        public string LicensePlate { get; set; } = string.Empty;

        /// <summary>
        /// Person Id (the car belongs to).
        /// </summary>
        [Required]
        public Guid PersonId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Person the car belongs to.
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public Person? Person { get; set; }

        [NotMapped]
        public bool Deleted { get; set; }
    }
}
