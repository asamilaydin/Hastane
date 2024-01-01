using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane.Entities
{
    [Table("Randevular")]
    public class Randevu
    {   
        public Guid Id { get; set; }
        [ForeignKey("Doktor")]
        public Guid DoktorId { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required]
        public DateTime RandevuTarihi { get; set; }
        [ForeignKey("User")]
        public Guid PoliklinikId { get; set; }
        [ForeignKey("User")]
        public Guid AnaBilimDaliId { get; set; }
        

        public Poliklinik poliklinik { get; set; }
        public User user { get; set; }
        public Doktor doktor { get; set; }
        public AnaBilimDali anaBilimDali { get; set; }

    }

}

