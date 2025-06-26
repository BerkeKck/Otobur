using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class Hebaryum : Migration
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
                    ToplayiciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AksesyonNumarasi", x => x.AksesyonNumarasi);
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
                    ToplayiciAdi = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciKodu = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ToplayiciNumarasi = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
