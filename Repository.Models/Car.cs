using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Models
{
    public class Car: Interfaces.IId
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
        /// Person Id (the car belongs to).
        /// </summary>
        [Required]
        public Guid PersonId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Person the car belongs to.
        /// </summary>
        [ForeignKey(nameof(PersonId))]
        public Person? Person { get; set; }
    }
}
