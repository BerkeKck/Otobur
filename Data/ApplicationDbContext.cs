using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using System;

namespace Otobur.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<AksesyonDefteri> AksesyonNumarasi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Configure the primary key for AksesyonDefteri  
            modelBuilder.Entity<AksesyonDefteri>().HasData(
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00345",
                    BitkininAdi = "Pinus pinea",
                    MateryalCesidi = "Canlı Bitki",
                    Koken = "Kültür; Köken bilinmiyor",
                    Lokasyon = "-",
                    Koordinat = "-",
                    ToplanmaTarihi = DateTime.MinValue,
                    ToplayiciAdi = "-",
                    ToplayiciKodu = "-",
                    ToplayiciNumarasi = "-"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00346",
                    BitkininAdi = "Cedrus libani",
                    MateryalCesidi = "Canlı Bitki",
                    Koken = "Köken bilgisi yok",
                    Lokasyon = "-",
                    Koordinat = "-",
                    ToplanmaTarihi = DateTime.MinValue,
                    ToplayiciAdi = "-",
                    ToplayiciKodu = "-",
                    ToplayiciNumarasi = "-"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00347",
                    BitkininAdi = "Aethionema turcica",
                    MateryalCesidi = "Tohum",
                    Koken = "Doğal",
                    Lokasyon = "Ankara; Beypazarı, Çakal gölü, 1750 m",
                    Koordinat = "39°52'45.34'' K - 32°15'43.45'' D",
                    ToplanmaTarihi = new DateTime(2025, 2, 3),
                    ToplayiciAdi = "Asil Güner",
                    ToplayiciKodu = "AG",
                    ToplayiciNumarasi = "12321"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00348",
                    BitkininAdi = "Cota tinctoria",
                    MateryalCesidi = "Tohum",
                    Koken = "Kültür; Köken Biliniyor",
                    Lokasyon = "-",
                    Koordinat = "-",
                    ToplanmaTarihi = DateTime.MinValue,
                    ToplayiciAdi = "-",
                    ToplayiciKodu = "-",
                    ToplayiciNumarasi = "-"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00349",
                    BitkininAdi = "Mespilus germanica",
                    MateryalCesidi = "Çelik",
                    Koken = "Kültür; Köken Biliniyor",
                    Lokasyon = "-",
                    Koordinat = "-",
                    ToplanmaTarihi = DateTime.MinValue,
                    ToplayiciAdi = "-",
                    ToplayiciKodu = "-",
                    ToplayiciNumarasi = "-"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00350",
                    BitkininAdi = "Malus sylvestris",
                    MateryalCesidi = "Canlı Bitki",
                    Koken = "Kültür; Köken Biliniyor",
                    Lokasyon = "-",
                    Koordinat = "-",
                    ToplanmaTarihi = DateTime.MinValue,
                    ToplayiciAdi = "-",
                    ToplayiciKodu = "-",
                    ToplayiciNumarasi = "-"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00351",
                    BitkininAdi = "Aucuba japonica",
                    MateryalCesidi = "Çelik",
                    Koken = "Kültür; Köken Biliniyor",
                    Lokasyon = "-",
                    Koordinat = "-",
                    ToplanmaTarihi = DateTime.MinValue,
                    ToplayiciAdi = "-",
                    ToplayiciKodu = "-",
                    ToplayiciNumarasi = "-"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00352",
                    BitkininAdi = "Pelargonium quercetorum",
                    MateryalCesidi = "Tohum",
                    Koken = "Doğal",
                    Lokasyon = "Bitlis; Tatvan, Demir Dağı, 1350 m",
                    Koordinat = "41°12'32.12'' K - 38°34'26.87'' D",
                    ToplanmaTarihi = new DateTime(2022, 5, 4),
                    ToplayiciAdi = "Salih Sercan Kanoğlu",
                    ToplayiciKodu = "SKNG",
                    ToplayiciNumarasi = "4532"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00353",
                    BitkininAdi = "Flueggea anatolica",
                    MateryalCesidi = "Tohum",
                    Koken = "Doğal",
                    Lokasyon = "Mersin; Kadıncık Vadisi, 455 m",
                    Koordinat = "37°24'33.01'' K - 34°23'24.53'' D",
                    ToplanmaTarihi = new DateTime(2023, 4, 3),
                    ToplayiciAdi = "Mahmut Can",
                    ToplayiciKodu = "MCAN",
                    ToplayiciNumarasi = "2345"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00354",
                    BitkininAdi = "Thermopsis turcica",
                    MateryalCesidi = "Tohum",
                    Koken = "Doğal",
                    Lokasyon = "Konya; Eber Gölü çevresi, 876 m",
                    Koordinat = "39°23'13.45'' K - 31°23'15.42'' D",
                    ToplanmaTarihi = new DateTime(2025, 6, 5),
                    ToplayiciAdi = "Birol Sever",
                    ToplayiciKodu = "BRLS",
                    ToplayiciNumarasi = "6754"
                },
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00355",
                    BitkininAdi = "Crocus biflorus",
                    MateryalCesidi = "Soğan",
                    Koken = "Doğal",
                    Lokasyon = "Erzincan; Keşiş Dağı, 1786 m",
                    Koordinat = "39°12'23.44'' K - 39°34'32.44'' D",
                    ToplanmaTarihi = new DateTime(2022, 12, 14),
                    ToplayiciAdi = "Emrah Çelik",
                    ToplayiciKodu = "ECLK",
                    ToplayiciNumarasi = "1201"
                }
            );
        }
    }
}