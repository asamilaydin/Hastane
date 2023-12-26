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
        public int DoktorId { get; set; }
        [ForeignKey("User")]
        public Guid UserId { get; set; }
        [Required]
        public DateTime RandevuTarihi { get; set; }
        // Diğer özellikler

    }

}

