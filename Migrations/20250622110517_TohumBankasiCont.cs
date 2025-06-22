using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class TohumBankasiCont : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "TohumBankasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00347");

            migrationBuilder.DeleteData(
                table: "TohumBankasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00348");

            migrationBuilder.DeleteData(
                table: "TohumBankasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00352");

            migrationBuilder.DeleteData(
                table: "TohumBankasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00353");

            migrationBuilder.DeleteData(
                table: "TohumBankasi",
                keyColumn: "AksesyonNumarasi",
                keyValue: "2023-00354");
        }
    }
}
