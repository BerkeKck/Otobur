using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class CreateToDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AksesyonDefteri",
                columns: table => new
                {
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    BitkininAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MateryalCesidi = table.Column<int>(type: "int", nullable: false),
                    Koken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Koordinat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplanmaTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToplayiciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AksesyonDefteri", x => x.AksesyonNumarasi);
                });

            migrationBuilder.CreateTable(
                name: "Kullanicilar",
                columns: table => new
                {
                    KullaniciAdi = table.Column<string>(type: "nvarchar(450)", nullable: false),
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
                    table.PrimaryKey("PK_Kullanicilar", x => x.KullaniciAdi);
                });

            migrationBuilder.CreateTable(
                name: "BitkiDurum",
                columns: table => new
                {
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    GozlemTarihi = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BahcedeBulunduguYer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    YerKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BitkininDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VejetasyonDurumu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gozlem = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BitkiDurum", x => x.AksesyonNumarasi);
                    table.ForeignKey(
                        name: "FK_BitkiDurum_AksesyonDefteri_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonDefteri",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HerbaryumDefteri",
                columns: table => new
                {
                    HerbaryumNo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BitkininAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Lokasyon = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Koordinat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Fotograf = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HerbaryumDefteri", x => x.HerbaryumNo);
                    table.ForeignKey(
                        name: "FK_HerbaryumDefteri_AksesyonDefteri_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonDefteri",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TohumBankasi",
                columns: table => new
                {
                    AksesyonNumarasi = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Miktar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BulunduguDolap = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TohumBankasi", x => x.AksesyonNumarasi);
                    table.ForeignKey(
                        name: "FK_TohumBankasi_AksesyonDefteri_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonDefteri",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AksesyonDefteri",
                columns: new[] { "AksesyonNumarasi", "BitkininAdi", "Koken", "Koordinat", "Lokasyon", "MateryalCesidi", "ToplanmaTarihi", "ToplayiciAdi", "ToplayiciKodu", "ToplayiciNumarasi" },
                values: new object[,]
                {
                    { "2023-00345", "Pinus pinea", "Kültür; Köken bilinmiyor", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00346", "Cedrus libani", "Köken bilgisi yok", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00347", "Aethionema turcica", "Doğal", "39°52'45.34'' K - 32°15'43.45'' D", "Ankara; Beypazarı, Çakal gölü, 1750 m", 4, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asil Güner", "AG", "12321" },
                    { "2023-00348", "Cota tinctoria", "Kültür; Köken Biliniyor", "-", "-", 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00349", "Mespilus germanica", "Kültür; Köken Biliniyor", "-", "-", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00350", "Malus sylvestris", "Kültür; Köken Biliniyor", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00351", "Aucuba japonica", "Kültür; Köken Biliniyor", "-", "-", 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00352", "Pelargonium quercetorum", "Doğal", "41°12'32.12'' K - 38°34'26.87'' D", "Bitlis; Tatvan, Demir Dağı, 1350 m", 4, new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salih Sercan Kanoğlu", "SKNG", "4532" },
                    { "2023-00353", "Flueggea anatolica", "Doğal", "37°24'33.01'' K - 34°23'24.53'' D", "Mersin; Kadıncık Vadisi, 455 m", 4, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahmut Can", "MCAN", "2345" },
                    { "2023-00354", "Thermopsis turcica", "Doğal", "39°23'13.45'' K - 31°23'15.42'' D", "Konya; Eber Gölü çevresi, 876 m", 4, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birol Sever", "BRLS", "6754" },
                    { "2023-00355", "Crocus biflorus", "Doğal", "39°12'23.44'' K - 39°34'32.44'' D", "Erzincan; Keşiş Dağı, 1786 m", 1, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emrah Çelik", "ECLK", "1201" }
                });

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciAdi", "Eposta", "GorebilecegiTablolar", "KayitSilebilme", "KayitYapabilecegiTablolar", "KullaniciGrubu", "KullaniciKodu", "Parola", "Telefon" },
                values: new object[,]
                {
                    { "Adil Güner", "ornek@gmail.com", "", false, "", "", "AG", "parola1", "0597 345 67 89" },
                    { "Birol Sever", "ornek3@gmail.com", "", false, "", "", "BRLS", "parola4", "0588 678 45 32" },
                    { "Emrah Çelik", "ornek4@gmail.com", "", false, "", "", "ECLK", "parola5", "0567 789 01 23" },
                    { "Mahmut Can", "ornek2@gmail.com", "", false, "", "", "MCAN", "parola3", "0589 980 76 54" },
                    { "Salih Sercan Kanoğlu", "ornek1@gmail.com", "", false, "", "", "SKNG", "parola2", "0587 123 45 67" }
                });

            migrationBuilder.InsertData(
                table: "BitkiDurum",
                columns: new[] { "AksesyonNumarasi", "BahcedeBulunduguYer", "BitkininDurumu", "Gozlem", "GozlemTarihi", "VejetasyonDurumu", "YerKodu" },
                values: new object[,]
                {
                    { "2023-00345", "Merkez Ada; Üst Gölet Alanı", "İyi", "-", new DateTime(2025, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yapraklı", "1-ÜG" },
                    { "2023-00346", "Etrüjül Adası; Bataklık Bölümü", "Mükemmel", "-", new DateTime(2025, 5, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yapraklı ve Kozalak Oluşumu Başlamış", "2-BB" },
                    { "2023-00350", "Trakya Adası; Meyve Bahçesi", "Vasat", "Yapraklarda buruşukluk hastalığı gözlendi, DECIS ilacı uygulandı", new DateTime(2025, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Yapraklı ve Çiçekli", "8-MB" }
                });

            migrationBuilder.InsertData(
                table: "HerbaryumDefteri",
                columns: new[] { "HerbaryumNo", "AksesyonNumarasi", "BitkininAdi", "Fotograf", "Koordinat", "Lokasyon", "ToplayiciAdi", "ToplayiciKodu", "ToplayiciNumarasi" },
                values: new object[,]
                {
                    { 123, "2023-00350", "Malus sylvestris", "Yok", "-", "-", "Bahçe Örneği", "-", "-" },
                    { 234, "2023-00355", "Crocus biflorus", "Var", "39°21'23,34'' K - 34°32'34,44'' D", "Erzincan; Keşiş Dağı, 1786 m", "Emrah Çelik", "ECLK", "1201" },
                    { 345, "2023-00354", "Thermopsis turcica", "Var", "33°23'12,54'' K - 25°34'34,32'' D", "Konya; Eber Gölü çevresi, 876 m", "Birol Sever", "BRLS", "6754" },
                    { 456, "2023-00347", "Aethionema turcica", "Var", "36°52'45,34'' K - 23°15'34,45'' D", "Ankara; Beypazarı, Çakal gölü, 1750 m", "Adil Güner", "AG", "12321" }
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
                column: "AksesyonNumarasi",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitkiDurum");

            migrationBuilder.DropTable(
                name: "HerbaryumDefteri");

            migrationBuilder.DropTable(
                name: "Kullanicilar");

            migrationBuilder.DropTable(
                name: "TohumBankasi");

            migrationBuilder.DropTable(
                name: "AksesyonDefteri");
        }
    }
}
