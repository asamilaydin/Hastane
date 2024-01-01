using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Hastane.Entities;

namespace Hastane.Models
{
   
    public class PoliklinikViewModel
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("AnaBilimDali")]
        public Guid AnaBilimDaliId { get; set; }


        public AnaBilimDali anaBilim { get; set; }
    }

}