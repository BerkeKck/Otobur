using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class AddAksesyonNumarasi : Migration
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
                    MateryalCesidi = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AksesyonNumarasi");
        }
    }
}
