using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class Fixup : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitkiDurum_AksesyonDefteri_AksesyonNumarasi",
                table: "BitkiDurum");

            migrationBuilder.DropForeignKey(
                name: "FK_HerbaryumDefteri_AksesyonDefteri_AksesyonNumarasi",
                table: "HerbaryumDefteri");

            migrationBuilder.DropForeignKey(
                name: "FK_TohumBankasi_AksesyonDefteri_AksesyonNumarasi",
                table: "TohumBankasi");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AksesyonDefteri",
                table: "AksesyonDefteri");

            migrationBuilder.RenameTable(
                name: "AksesyonDefteri",
                newName: "AksesyonNumarasi");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AksesyonNumarasi",
                table: "AksesyonNumarasi",
                column: "AksesyonNumarasi");

            migrationBuilder.AddForeignKey(
                name: "FK_BitkiDurum_AksesyonNumarasi_AksesyonNumarasi",
                table: "BitkiDurum",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonNumarasi",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HerbaryumDefteri_AksesyonNumarasi_AksesyonNumarasi",
                table: "HerbaryumDefteri",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonNumarasi",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TohumBankasi_AksesyonNumarasi_AksesyonNumarasi",
                table: "TohumBankasi",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonNumarasi",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BitkiDurum_AksesyonNumarasi_AksesyonNumarasi",
                table: "BitkiDurum");

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
                newName: "AksesyonDefteri");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AksesyonDefteri",
                table: "AksesyonDefteri",
                column: "AksesyonNumarasi");

            migrationBuilder.AddForeignKey(
                name: "FK_BitkiDurum_AksesyonDefteri_AksesyonNumarasi",
                table: "BitkiDurum",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonDefteri",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_HerbaryumDefteri_AksesyonDefteri_AksesyonNumarasi",
                table: "HerbaryumDefteri",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonDefteri",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_TohumBankasi_AksesyonDefteri_AksesyonNumarasi",
                table: "TohumBankasi",
                column: "AksesyonNumarasi",
                principalTable: "AksesyonDefteri",
                principalColumn: "AksesyonNumarasi",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
