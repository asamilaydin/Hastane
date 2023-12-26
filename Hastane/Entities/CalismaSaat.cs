using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Hastane.Entities
{
    [Table("CalismaSaatleri")]
    public class CalısmaSaat
    {
        [Key]
        public Guid Id { get; set; }
        [ForeignKey("Doktor")]
        public Guid DoktorId { get; set; }
        [Required]
        [StringLength(100)]
        public string Gun { get; set; }
        [Required]
        public TimeSpan BaslangıcSaat { get; set; }
        [Required]
        public TimeSpan BitisSaat { get; set; }
        // Diğer özellikler

        
    }

}

