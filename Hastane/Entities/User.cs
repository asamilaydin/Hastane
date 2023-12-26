using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hastane.Entities
{
 [Table("Users")]
public class User
{
    [Key]
    public Guid UserID { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        [StringLength(50)]
        public string Surname { get; set; }

        [Required]
    [StringLength(30)]
    public string Username { get; set; }

    [Required]
    [StringLength(100)]
    public string Password { get; set; }

    public bool Locked { get; set; } = false;
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    [Required]
    [StringLength(50)]
    public string Role { get; set; } = "user";

        public virtual ICollection<Randevu> Randevular { get; set; }
    }
}