using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class KeyStructureBetweenTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AksesyonNumarasi",
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
                    table.PrimaryKey("PK_AksesyonNumarasi", x => x.AksesyonNumarasi);
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
                        name: "FK_HerbaryumDefteri_AksesyonNumarasi_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonNumarasi",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AksesyonNumarasi",
                columns: new[] { "AksesyonNumarasi", "BitkininAdi", "Koken", "Koordinat", "Lokasyon", "MateryalCesidi", "ToplanmaTarihi", "ToplayiciAdi", "ToplayiciKodu", "ToplayiciNumarasi" },
                values: new object[,]
                {
                    { "2023-00345", "Pinus pinea", "Kültür; Köken bilinmiyor", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00346", "Cedrus libani", "Köken bilgisi yok", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00347", "Aethionema turcica", "Doğal", "39°52'45.34'' K - 32°15'43.45'' D", "Ankara; Beypazarı, Çakal gölü, 1750 m", 1, new DateTime(2025, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Asil Güner", "AG", "12321" },
                    { "2023-00348", "Cota tinctoria", "Kültür; Köken Biliniyor", "-", "-", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00349", "Mespilus germanica", "Kültür; Köken Biliniyor", "-", "-", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00350", "Malus sylvestris", "Kültür; Köken Biliniyor", "-", "-", 0, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00351", "Aucuba japonica", "Kültür; Köken Biliniyor", "-", "-", 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "-", "-", "-" },
                    { "2023-00352", "Pelargonium quercetorum", "Doğal", "41°12'32.12'' K - 38°34'26.87'' D", "Bitlis; Tatvan, Demir Dağı, 1350 m", 1, new DateTime(2022, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Salih Sercan Kanoğlu", "SKNG", "4532" },
                    { "2023-00353", "Flueggea anatolica", "Doğal", "37°24'33.01'' K - 34°23'24.53'' D", "Mersin; Kadıncık Vadisi, 455 m", 1, new DateTime(2023, 4, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Mahmut Can", "MCAN", "2345" },
                    { "2023-00354", "Thermopsis turcica", "Doğal", "39°23'13.45'' K - 31°23'15.42'' D", "Konya; Eber Gölü çevresi, 876 m", 1, new DateTime(2025, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Birol Sever", "BRLS", "6754" },
                    { "2023-00355", "Crocus biflorus", "Doğal", "39°12'23.44'' K - 39°34'32.44'' D", "Erzincan; Keşiş Dağı, 1786 m", 3, new DateTime(2022, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emrah Çelik", "ECLK", "1201" }
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
                name: "HerbaryumDefteri");

            migrationBuilder.DropTable(
                name: "AksesyonNumarasi");
        }
    }
}
