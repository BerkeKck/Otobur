using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class TohumBankasi : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                        name: "FK_TohumBankasi_AksesyonNumarasi_AksesyonNumarasi",
                        column: x => x.AksesyonNumarasi,
                        principalTable: "AksesyonNumarasi",
                        principalColumn: "AksesyonNumarasi",
                        onDelete: ReferentialAction.Restrict);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TohumBankasi");
        }
    }
}
