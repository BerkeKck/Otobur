using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class Aksesyonlar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitkiDurumu_AksesyonNumarasi_AksesyonNumarasi",
                table: "BitkiDurumu");

            migrationBuilder.DropForeignKey(
                name: "FK_HerbaryumDefteri_AksesyonNumarasi_AksesyonNumarasi",
                table: "HerbaryumDefteri");

            migrationBuilder.DropForeignKey(
                name: "FK_TohumBankasi_AksesyonNumarasi_AksesyonNumarasi",
                table: "TohumBankasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AksesyonNumarasi",
                table: "AksesyonNumarasi");

            migrationBuilder.RenameTable(
                name: "AksesyonNumarasi",
                newName: "Aksesyonlar");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Aksesyonlar",
                table: "Aksesyonlar",
                column: "AksesyonNumarasi");

            migrationBuilder.AddForeignKey(
                name: "FK_BitkiDurumu_Aksesyonlar_AksesyonNumarasi",
                table: "BitkiDurumu",
                column: "AksesyonNumarasi",
                principalTable: "Aksesyonlar",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HerbaryumDefteri_Aksesyonlar_AksesyonNumarasi",
                table: "HerbaryumDefteri",
                column: "AksesyonNumarasi",
                principalTable: "Aksesyonlar",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TohumBankasi_Aksesyonlar_AksesyonNumarasi",
                table: "TohumBankasi",
                column: "AksesyonNumarasi",
                principalTable: "Aksesyonlar",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitkiDurumu_Aksesyonlar_AksesyonNumarasi",
                table: "BitkiDurumu");

            migrationBuilder.DropForeignKey(
                name: "FK_HerbaryumDefteri_Aksesyonlar_AksesyonNumarasi",
                table: "HerbaryumDefteri");

            migrationBuilder.DropForeignKey(
                name: "FK_TohumBankasi_Aksesyonlar_AksesyonNumarasi",
                table: "TohumBankasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Aksesyonlar",
                table: "Aksesyonlar");

            migrationBuilder.RenameTable(
                name: "Aksesyonlar",
                newName: "AksesyonNumarasi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AksesyonNumarasi",
                table: "AksesyonNumarasi",
                column: "AksesyonNumarasi");

            migrationBuilder.AddForeignKey(
                name: "FK_BitkiDurumu_AksesyonNumarasi_AksesyonNumarasi",
                table: "BitkiDurumu",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonNumarasi",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HerbaryumDefteri_AksesyonNumarasi_AksesyonNumarasi",
                table: "HerbaryumDefteri",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonNumarasi",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TohumBankasi_AksesyonNumarasi_AksesyonNumarasi",
                table: "TohumBankasi",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonNumarasi",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
