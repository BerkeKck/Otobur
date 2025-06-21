using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class Aksesyon : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "MateryalCesidi",
                table: "AksesyonNumarasi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00345",
                column: "MateryalCesidi",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00346",
                column: "MateryalCesidi",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00347",
                column: "MateryalCesidi",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00348",
                column: "MateryalCesidi",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00349",
                column: "MateryalCesidi",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00350",
                column: "MateryalCesidi",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00351",
                column: "MateryalCesidi",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00352",
                column: "MateryalCesidi",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00353",
                column: "MateryalCesidi",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00354",
                column: "MateryalCesidi",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00355",
                column: "MateryalCesidi",
                value: 3);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "MateryalCesidi",
                table: "AksesyonNumarasi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00345",
                column: "MateryalCesidi",
                value: "Canlı Bitki");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00346",
                column: "MateryalCesidi",
                value: "Canlı Bitki");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00347",
                column: "MateryalCesidi",
                value: "Tohum");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00348",
                column: "MateryalCesidi",
                value: "Tohum");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00349",
                column: "MateryalCesidi",
                value: "Çelik");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00350",
                column: "MateryalCesidi",
                value: "Canlı Bitki");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00351",
                column: "MateryalCesidi",
                value: "Çelik");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00352",
                column: "MateryalCesidi",
                value: "Tohum");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00353",
                column: "MateryalCesidi",
                value: "Tohum");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00354",
                column: "MateryalCesidi",
                value: "Tohum");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00355",
                column: "MateryalCesidi",
                value: "Soğan");
        }
    }
}
