using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class ToplayiciToKullanici : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AksesyonNumarasi",
                columns: table => new
                {
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    BitkininAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MateryalCesidi = table.Column<int>(type: "int", nullable: false),
                    Koken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Koordinat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AksesyonNumarasi", x => x.AksesyonNumarasi);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciNumarasi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Parola = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Eposta = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GorebilecegiTablolar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitYapabilecegiTablolar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KayitSilebilme = table.Column<bool>(type: "bit", nullable: false),
                    KullaniciGrubu = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciNumarasi);
                });

            migrationBuilder.CreateTable(
                name: "BitkiDurumu",
                columns: table => new
                {
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    GozlemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BahcedeBulunduguYer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YerKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitkininDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VejetasyonDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gozlem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitkiDurumu", x => x.AksesyonNumarasi);
                    table.ForeignKey(
                        name: "FK_BitkiDurumu_AksesyonNumarasi_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonNumarasi",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HerbaryumDefteri",
                columns: table => new
                {
                    HerbaryumNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BitkininAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KullaniciNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Koordinat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HerbaryumDefteri", x => x.HerbaryumNo);
                    table.ForeignKey(
                        name: "FK_HerbaryumDefteri_AksesyonNumarasi_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonNumarasi",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TohumBankasi",
                columns: table => new
                {
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(20)", nullable: false),
                    Miktar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BulunduguDolap = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TohumBankasi", x => x.AksesyonNumarasi);
                    table.ForeignKey(
                        name: "FK_TohumBankasi_AksesyonNumarasi_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonNumarasi",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AksesyonNumarasi",
                columns: new[] { "AksesyonNumarasi", "BitkininAdi", "Koken", "Koordinat", "KullaniciAdi", "KullaniciKodu", "KullaniciNumarasi", "Lokasyon", "MateryalCesidi", "ToplanmaTarihi" },
                values: new object[,]
                {
                    { "2023-00345", "Pinus pinea", "Kültür; Köken bilinmiyor", "-", "-", "-", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00346", "Cedrus libani", "Köken bilgisi yok", "-", "-", "-", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00347", "Aethionema turcica", "Doğal", "39°52'45.34'' K - 32°15'43.45'' D", "Asil Güner", "AG", "12321", "Ankara; Beypazarı, Çakal gölü, 1750 m", 4, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00348", "Cota tinctoria", "Kültür; Köken Biliniyor", "-", "-", "-", "-", "-", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00349", "Mespilus germanica", "Kültür; Köken Biliniyor", "-", "-", "-", "-", "-", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00350", "Malus sylvestris", "Kültür; Köken Biliniyor", "-", "-", "-", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00351", "Aucuba japonica", "Kültür; Köken Biliniyor", "-", "-", "-", "-", "-", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00352", "Pelargonium quercetorum", "Doğal", "41°12'32.12'' K - 38°34'26.87'' D", "Salih Sercan Kanoğlu", "SKNG", "4532", "Bitlis; Tatvan, Demir Dağı, 1350 m", 4, new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00353", "Flueggea anatolica", "Doğal", "37°24'33.01'' K - 34°23'24.53'' D", "Mahmut Can", "MCAN", "2345", "Mersin; Kadıncık Vadisi, 455 m", 4, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00354", "Thermopsis turcica", "Doğal", "39°23'13.45'' K - 31°23'15.42'' D", "Birol Sever", "BRLS", "6754", "Konya; Eber Gölü çevresi, 876 m", 4, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { "2023-00355", "Crocus biflorus", "Doğal", "39°12'23.44'' K - 39°34'32.44'' D", "Emrah Çelik", "ECLK", "1201", "Erzincan; Keşiş Dağı, 1786 m", 1, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "BitkiDurumu",
                columns: new[] { "AksesyonNumarasi", "BahcedeBulunduguYer", "BitkininDurumu", "Gozlem", "GozlemTarihi", "VejetasyonDurumu", "YerKodu" },
                values: new object[,]
                {
                    { "2023-00345", "Merkez Ada; Üst Gölet Alanı", "İyi", "-", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yapraklı", "1-ÜG" },
                    { "2023-00346", "Ertuğrul Adası; Bataklık Bölümü", "Mükemmel", "-", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yapraklı ve Kozalak Oluşumu Başlamış", "2-BB" },
                    { "2023-00350", "Trakya Adası; Meyve Bahçesi", "Vasat", "Yapraklarda buruşukluk hastalığı gözlendi, DECIS ilacı uygulandı", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yapraklı ve Çiçekli", "8-MB" }
                });

            migrationBuilder.InsertData(
                table: "HerbaryumDefteri",
                columns: new[] { "HerbaryumNo", "AksesyonNumarasi", "BitkininAdi", "Fotograf", "Koordinat", "KullaniciAdi", "KullaniciKodu", "KullaniciNumarasi", "Lokasyon" },
                values: new object[,]
                {
                    { 123, "2023-00350", "Malus sylvestris", "Yok", "-", "Bahçe Örneği", "-", "-", "-" },
                    { 234, "2023-00355", "Crocus biflorus", "Var", "39°21'23,34'' K - 34°32'34,44'' D", "Emrah Çelik", "ECLK", "1201", "Erzincan; Keşiş Dağı, 1786 m." },
                    { 345, "2023-00354", "Thermopsis turcica", "Var", "39°23'12,54'' K - 25°34'34,32'' D", "Birol Sever", "BRLS", "6754", "Konya; Eber Gölü çevresi, 876 m." },
                    { 456, "2023-00347", "Aethionema turcica", "Var", "36°52'45,34'' K - 23°15'34,45'' D", "Adil Güner", "AG", "12321", "Ankara; Beypazarı, Çakal gölü, 1750 m." }
                });

            migrationBuilder.InsertData(
                table: "TohumBankasi",
                columns: new[] { "AksesyonNumarasi", "BulunduguDolap", "Miktar" },
                values: new object[,]
                {
                    { "2023-00347", "1A3", "1 küçük şişe (30cl)" },
                    { "2023-00348", "2B4", "1 küçük şişe (30cl), 1 büyük şişe (100cl)" },
                    { "2023-00352", "3A2", "1 orta şişe (50 cl)" },
                    { "2023-00353", "2D3", "1 büyük şişe (100 cl)" },
                    { "2023-00354", "1A2", "1 orta şişe (50 cl), 2 büyük şişe (100 cl)" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_HerbaryumDefteri_AksesyonNumarasi",
                table: "HerbaryumDefteri",
                column: "AksesyonNumarasi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitkiDurumu");

            migrationBuilder.DropTable(
                name: "HerbaryumDefteri");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "TohumBankasi");

            migrationBuilder.DropTable(
                name: "AksesyonNumarasi");
        }
    }
}
