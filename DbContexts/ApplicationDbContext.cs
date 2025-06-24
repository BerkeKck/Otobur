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
        public DbSet<Aksesyon> AksesyonNumarasi { get; set; }
        public DbSet<Herbaryum> HerbaryumDefteri { get; set; }
        public DbSet<TohumBankasi> TohumBankasi { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<BitkiDurum> BitkiDurumu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //AksesyonDefteri  
            modelBuilder.Entity<Aksesyon>().HasData(
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
                new Aksesyon
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
        }
    }
}