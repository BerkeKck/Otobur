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
        public DbSet<Aksesyon> Aksesyonlar { get; set; }
        public DbSet<Herbaryum> HerbaryumDefteri { get; set; }
        public DbSet<TohumBankasi> TohumBankasi { get; set; }
        public DbSet<Kullanici> Kullanicilar { get; set; }
        public DbSet<BitkiDurum> BitkiDurumu { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //RELATIONS
            modelBuilder.Entity<Herbaryum>()
                    .HasOne(h => h.Aksesyon)
                    .WithMany() // or .WithMany(a => a.Herbaryumlar) if you have a collection
                    .HasForeignKey(h => h.AksesyonNumarasi)
                    .HasPrincipalKey(a => a.AksesyonNumarasi);
            modelBuilder.Entity<Aksesyon>()
                   .HasOne(a => a.BitkiDurum)
                   .WithOne(b => b.Aksesyon)
                   .HasForeignKey<BitkiDurum>(b => b.AksesyonNumarasi);

            modelBuilder.Entity<Aksesyon>()
                   .HasOne(a => a.TohumBankasi)
                   .WithOne(t => t.Aksesyon)
                   .HasForeignKey<TohumBankasi>(t => t.AksesyonNumarasi);


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
                    KullaniciAdi = "-",
                    KullaniciKodu = "-",
                    KullaniciNumarasi = "-"
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
                    KullaniciAdi = "-",
                    KullaniciKodu = "-",
                    KullaniciNumarasi = "-"
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
                    KullaniciAdi = "Asil Güner",
                    KullaniciKodu = "AG",
                    KullaniciNumarasi = "12321"
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
                    KullaniciAdi = "-",
                    KullaniciKodu = "-",
                    KullaniciNumarasi = "-"
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
                    KullaniciAdi = "-",
                    KullaniciKodu = "-",
                    KullaniciNumarasi = "-"
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
                    KullaniciAdi = "-",
                    KullaniciKodu = "-",
                    KullaniciNumarasi = "-"
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
                    KullaniciAdi = "-",
                    KullaniciKodu = "-",
                    KullaniciNumarasi = "-"
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
                    KullaniciAdi = "Salih Sercan Kanoğlu",
                    KullaniciKodu = "SKNG",
                    KullaniciNumarasi = "4532"
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
                    KullaniciAdi = "Mahmut Can",
                    KullaniciKodu = "MCAN",
                    KullaniciNumarasi = "2345"
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
                    KullaniciAdi = "Birol Sever",
                    KullaniciKodu = "BRLS",
                    KullaniciNumarasi = "6754"
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
                    KullaniciAdi = "Emrah Çelik",
                    KullaniciKodu = "ECLK",
                    KullaniciNumarasi = "1201"
                }
                );
            // HerbaryumDefteri
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Herbaryum>().HasData(
                new Herbaryum
                {
                    HerbaryumNo = 345,
                    BitkininAdi = "Thermopsis turcica",
                    KullaniciAdi = "Birol Sever",
                    KullaniciKodu = "BRLS",
                    KullaniciNumarasi = "6754",
                    Lokasyon = "Konya; Eber Gölü çevresi, 876 m.",
                    Koordinat = "39°23'12,54'' K - 25°34'34,32'' D",
                    AksesyonNumarasi = "2023-00354",
                    Fotograf = "Var"
                },
                new Herbaryum
                {
                    HerbaryumNo = 234,
                    BitkininAdi = "Crocus biflorus",
                    KullaniciAdi = "Emrah Çelik",
                    KullaniciKodu = "ECLK",
                    KullaniciNumarasi = "1201",
                    Lokasyon = "Erzincan; Keşiş Dağı, 1786 m.",
                    Koordinat = "39°21'23,34'' K - 34°32'34,44'' D",
                    AksesyonNumarasi = "2023-00355",
                    Fotograf = "Var"
                },
                new Herbaryum
                {
                    HerbaryumNo = 123,
                    BitkininAdi = "Malus sylvestris",
                    KullaniciAdi = "Bahçe Örneği",
                    KullaniciKodu = "-",
                    KullaniciNumarasi = "-",
                    Lokasyon = "-",
                    Koordinat = "-",
                    AksesyonNumarasi = "2023-00350",
                    Fotograf = "Yok"
                },
                new Herbaryum
                {
                    HerbaryumNo = 456,
                    BitkininAdi = "Aethionema turcica",
                    KullaniciAdi = "Adil Güner",
                    KullaniciKodu = "AG",
                    KullaniciNumarasi = "12321",
                    Lokasyon = "Ankara; Beypazarı, Çakal gölü, 1750 m.",
                    Koordinat = "36°52'45,34'' K - 23°15'34,45'' D",
                    AksesyonNumarasi = "2023-00347",
                    Fotograf = "Var"
                }
            );
            // BitkiDurumDefteri
            modelBuilder.Entity<BitkiDurum>().HasData(
                new BitkiDurum
                {
                    AksesyonNumarasi = "2023-00345",
                    GozlemTarihi = new DateTime(2025, 4, 12),
                    BahcedeBulunduguYer = "Merkez Ada; Üst Gölet Alanı",
                    YerKodu = "1-ÜG",
                    BitkininDurumu = "İyi",
                    VejetasyonDurumu = "Yapraklı",
                    Gozlem = "-"
                },
                new BitkiDurum
                {
                    AksesyonNumarasi = "2023-00346",
                    GozlemTarihi = new DateTime(2025, 5, 13),
                    BahcedeBulunduguYer = "Ertuğrul Adası; Bataklık Bölümü",
                    YerKodu = "2-BB",
                    BitkininDurumu = "Mükemmel",
                    VejetasyonDurumu = "Yapraklı ve Kozalak Oluşumu Başlamış",
                    Gozlem = "-"
                },
                new BitkiDurum
                {
                    AksesyonNumarasi = "2023-00350",
                    GozlemTarihi = new DateTime(2025, 3, 1),
                    BahcedeBulunduguYer = "Trakya Adası; Meyve Bahçesi",
                    YerKodu = "8-MB",
                    BitkininDurumu = "Vasat",
                    VejetasyonDurumu = "Yapraklı ve Çiçekli",
                    Gozlem = "Yapraklarda buruşukluk hastalığı gözlendi, DECIS ilacı uygulandı"
                }
            );
            // TohumBankasi
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
            // Kullanicilar
            modelBuilder.Entity<Kullanici>().HasData(
                new Kullanici
                {
                    KullaniciNumarasi = "1",
                    KullaniciAdi = "Salih Kanoğlu",
                    KullaniciKodu = "",
                    Parola = "1234",
                    Telefon = "",
                    Eposta = "",
                    GorebilecegiTablolar = "Tüm Tablolar",
                    KayitYapabilecegiTablolar = "Tüm Tablolar",
                    KayitSilebilme = true,
                    KullaniciGrubu = "Sistem Yöneticisi"
                },
                new Kullanici
                {
                    KullaniciNumarasi = "2",
                    KullaniciAdi = "Adil Güner",
                    KullaniciKodu = "",
                    Parola = "5678",
                    Telefon = "",
                    Eposta = "",
                    GorebilecegiTablolar = "Toplayıcı Defteri, Herbaryum Tablosu",
                    KayitYapabilecegiTablolar = "Toplayıcı Defteri, Herbaryum Tablosu",
                    KayitSilebilme = false,
                    KullaniciGrubu = "Normal Kullanıcı"
                },
                new Kullanici
                {
                    KullaniciNumarasi = "3",
                    KullaniciAdi = "Ali Çelik",
                    KullaniciKodu = "",
                    Parola = "9876",
                    Telefon = "",
                    Eposta = "",
                    GorebilecegiTablolar = "Aksesyon Tablosu, Tohum Bankası Tablosu, Bitki Durum Tablosu",
                    KayitYapabilecegiTablolar = "Aksesyon Tablosu, Tohum Bankası Tablosu, Bitki Durum Tablosu",
                    KayitSilebilme = false,
                    KullaniciGrubu = "Normal Kullanıcı"
                },
                new Kullanici
                {
                    KullaniciNumarasi = "4",
                    KullaniciAdi = "Osman Tek",
                    KullaniciKodu = "",
                    Parola = "2468",
                    Telefon = "",
                    Eposta = "",
                    GorebilecegiTablolar = "Sadece Kayıtları Görebilir",
                    KayitYapabilecegiTablolar = "Kayıt Yapamaz",
                    KayitSilebilme = false,
                    KullaniciGrubu = "Eğitimde"
                }
            );
        }
    }
    }
