using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane.Entities
{
    [Table("Poliklinikler")]
    public class Poliklinik
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("AnaBilimDali")]
        public Guid AnaBilimDaliId { get; set; }
        public AnaBilimDali AnaBilimDali { get; set; }


        public virtual ICollection<Doktor> Doktorlar { get; set; }
        public virtual ICollection<Randevu> Randevular { get; set; }
    }

}

