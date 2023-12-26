using Hastane.Data;
using Hastane.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hastane.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    public DbSet<User> Users { get; set; }
    public DbSet<AnaBilimDali> AnaBilimDallari { get; set; }
    public DbSet<Poliklinik> Poliklinikler  { get; set; }
    public DbSet<Doktor> Doktorlar{ get; set; }
    public DbSet<CalısmaSaat> CalısmaSaatleri { get; set; }
    public DbSet<Randevu> Randevular { get; set; }

}

