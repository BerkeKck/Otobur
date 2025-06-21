using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class AksesyonKokenFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Koken",
                table: "AksesyonNumarasi",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00345",
                column: "Koken",
                value: 0);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00346",
                column: "Koken",
                value: 3);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00347",
                column: "Koken",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00348",
                column: "Koken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00349",
                column: "Koken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00350",
                column: "Koken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00351",
                column: "Koken",
                value: 1);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00352",
                column: "Koken",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00353",
                column: "Koken",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00354",
                column: "Koken",
                value: 2);

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00355",
                column: "Koken",
                value: 2);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Koken",
                table: "AksesyonNumarasi",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00345",
                column: "Koken",
                value: "Kültür; Köken bilinmiyor");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00346",
                column: "Koken",
                value: "Köken bilgisi yok");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00347",
                column: "Koken",
                value: "Doğal");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00348",
                column: "Koken",
                value: "Kültür; Köken Biliniyor");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00349",
                column: "Koken",
                value: "Kültür; Köken Biliniyor");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00350",
                column: "Koken",
                value: "Kültür; Köken Biliniyor");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00351",
                column: "Koken",
                value: "Kültür; Köken Biliniyor");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00352",
                column: "Koken",
                value: "Doğal");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00353",
                column: "Koken",
                value: "Doğal");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00354",
                column: "Koken",
                value: "Doğal");

            migrationBuilder.UpdateData(
                table: "AksesyonNumarasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00355",
                column: "Koken",
                value: "Doğal");
        }
    }
}
