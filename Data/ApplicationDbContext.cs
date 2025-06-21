using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Otobur.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AksesyonDefteri> AksesyonNumarasi { get; set; }
        //public DbSet<AksesyonDefteri> BitkininAdi { get; set; }
        //public DbSet<AksesyonDefteri> MateryalCesidi { get; set; }
        //public DbSet<AksesyonDefteri> Koken { get; set; }
        //public DbSet<AksesyonDefteri> Lokasyon { get; set; }
        //public DbSet<AksesyonDefteri> Koordinat { get; set; }
        //public DbSet<AksesyonDefteri> ToplanmaTarihi { get; set; }
        //public DbSet<AksesyonDefteri> ToplayiciAdi { get; set; }
        //public DbSet<AksesyonDefteri> ToplayiciKodu { get; set; }
        //public DbSet<AksesyonDefteri> ToplayiciNumarasi { get; set; }


    }
}
