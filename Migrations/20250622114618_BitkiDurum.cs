using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class BitkiDurum : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_BitkiDurum_AksesyonNumarasi_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonNumarasi",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Restrict);
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BitkiDurum");
        }
    }
}
