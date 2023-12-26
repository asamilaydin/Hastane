using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Hastane.Entities
{
    [Table("Doktorlar")]
    public class Doktor
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
        [ForeignKey("Poliklinik")]
        public Guid PoliklinikId { get; set; }
        // Diğer özellikler

        public virtual ICollection<CalısmaSaat> CalısmaSaatleri { get; set; }
        public virtual ICollection<Randevu> Randevular{ get; set; }
    }

}

