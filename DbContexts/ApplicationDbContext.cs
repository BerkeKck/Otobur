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
        public DbSet<HerbaryumDefteri> HerbaryumDefteri { get; set; }
        public DbSet<TohumBankasi> TohumBankasi { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AksesyonDefteri  
            modelBuilder.Entity<AksesyonDefteri>().HasData(
                new AksesyonDefteri
                {
                    AksesyonNumarasi = "2023-00345",
                    BitkininAdi = "Pinus pinea",
                    MateryalCesidi = MateryalCesidiEnum.CanlıBitki,
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
                    MateryalCesidi = MateryalCesidiEnum.CanlıBitki,
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
                    MateryalCesidi = MateryalCesidiEnum.Tohum,
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
                    MateryalCesidi = MateryalCesidiEnum.Tohum,
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
                    MateryalCesidi = MateryalCesidiEnum.Çelik,
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
                    MateryalCesidi = MateryalCesidiEnum.CanlıBitki,
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
                    MateryalCesidi = MateryalCesidiEnum.Çelik,
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
                    MateryalCesidi = MateryalCesidiEnum.Tohum,
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
                    MateryalCesidi = MateryalCesidiEnum.Tohum,
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
                    MateryalCesidi = MateryalCesidiEnum.Tohum,
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
                    MateryalCesidi = MateryalCesidiEnum.Soğan,
                    Koken = "Doğal",
                    Lokasyon = "Erzincan; Keşiş Dağı, 1786 m",
                    Koordinat = "39°12'23.44'' K - 39°34'32.44'' D",
                    ToplanmaTarihi = new DateTime(2022, 12, 14),
                    ToplayiciAdi = "Emrah Çelik",
                    ToplayiciKodu = "ECLK",
                    ToplayiciNumarasi = "1201"
                }
                );
            // HerbaryumDefteri HasData
            modelBuilder.Entity<HerbaryumDefteri>()
                   .HasOne(h => h.Aksesyon)
                   .WithOne(a => a.Herbaryum)
                   .HasForeignKey<HerbaryumDefteri>(h => h.AksesyonNumarasi)
                   .HasPrincipalKey<AksesyonDefteri>(a => a.AksesyonNumarasi)
                   .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<HerbaryumDefteri>().HasData(
            new HerbaryumDefteri
            {
                HerbaryumNo = 345,
                BitkininAdi = "Thermopsis turcica",
                ToplayiciAdi = "Birol Sever",
                ToplayiciKodu = "BRLS",
                ToplayiciNumarasi = "6754",
                Lokasyon = "Konya; Eber Gölü çevresi, 876 m",
                Koordinat = "33°23'12,54'' K - 25°34'34,32'' D",
                AksesyonNumarasi = "2023-00354",
                Fotograf = "Var"
            },
            new HerbaryumDefteri
            {
                HerbaryumNo = 234,
                BitkininAdi = "Crocus biflorus",
                ToplayiciAdi = "Emrah Çelik",
                ToplayiciKodu = "ECLK",
                ToplayiciNumarasi = "1201",
                Lokasyon = "Erzincan; Keşiş Dağı, 1786 m",
                Koordinat = "39°21'23,34'' K - 34°32'34,44'' D",
                AksesyonNumarasi = "2023-00355",
                Fotograf = "Var"
            },
            new HerbaryumDefteri
            {
                HerbaryumNo = 123,
                BitkininAdi = "Malus sylvestris",
                ToplayiciAdi = "Bahçe Örneği",
                ToplayiciKodu = "-",
                ToplayiciNumarasi = "-",
                Lokasyon = "-",
                Koordinat = "-",
                AksesyonNumarasi = "2023-00350",
                Fotograf = "Yok"
            },
            new HerbaryumDefteri
            {
                HerbaryumNo = 456,
                BitkininAdi = "Aethionema turcica",
                ToplayiciAdi = "Adil Güner",
                ToplayiciKodu = "AG",
                ToplayiciNumarasi = "12321",
                Lokasyon = "Ankara; Beypazarı, Çakal gölü, 1750 m",
                Koordinat = "36°52'45,34'' K - 23°15'34,45'' D",
                AksesyonNumarasi = "2023-00347",
                Fotograf = "Var"
            }
    );

            // TohumBankasi ile AksesyonDefteri arasında birebir ilişki
            modelBuilder.Entity<TohumBankasi>()
                .HasOne(t => t.Aksesyon)
                .WithOne()
                .HasForeignKey<TohumBankasi>(t => t.AksesyonNumarasi)
                .HasPrincipalKey<AksesyonDefteri>(a => a.AksesyonNumarasi)
                .OnDelete(DeleteBehavior.Restrict);

            // TohumBankasi seed
            modelBuilder.Entity<TohumBankasi>().HasData(
                new TohumBankasi
                {
                    AksesyonNumarasi = "2023-00347",
                    Miktar = "1 küçük şişe (30cl)",
                    BulunduguDolap = "1A3"
                },
                new TohumBankasi
                {
                    AksesyonNumarasi = "2023-00348",
                    Miktar = "1 küçük şişe (30cl), 1 büyük şişe (100cl)",
                    BulunduguDolap = "2B4"
                },
                new TohumBankasi
                {
                    AksesyonNumarasi = "2023-00352",
                    Miktar = "1 orta şişe (50 cl)",
                    BulunduguDolap = "3A2"
                },
                new TohumBankasi
                {
                    AksesyonNumarasi = "2023-00353",
                    Miktar = "1 büyük şişe (100 cl)",
                    BulunduguDolap = "2D3"
                },
                new TohumBankasi
                {
                    AksesyonNumarasi = "2023-00354",
                    Miktar = "1 orta şişe (50 cl), 2 büyük şişe (100 cl)",
                    BulunduguDolap = "1A2"
                }
                );
            }
        }
}