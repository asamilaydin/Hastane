using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane.Entities
{
    [Table("AnaBilimDallari")]
    public class AnaBilimDali
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Poliklinik> Poliklinikler { get; set; }
        public virtual ICollection<Randevu> Randevular { get; set; }

    }

}

