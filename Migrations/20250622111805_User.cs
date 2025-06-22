using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class User : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciAdi", "Eposta", "GorebilecegiTablolar", "KayitSilebilme", "KayitYapabilecegiTablolar", "KullaniciGrubu", "KullaniciKodu", "Parola", "Telefon" },
                values: new object[,]
                {
                    { "Adil Güner", "ornek@gmail.com", "", false, "", "", "AG", "parola1", "0597 345 67 89" },
                    { "Birol Sever", "ornek3@gmail.com", "", false, "", "", "BRLS", "parola4", "0588 678 45 32" },
                    { "Emrah Çelik", "ornek4@gmail.com", "", false, "", "", "ECLK", "parola5", "0567 789 01 23" },
                    { "Mahmut Can", "ornek2@gmail.com", "", false, "", "", "MCAN", "parola3", "0589 980 76 54" },
                    { "Salih Sercan Kanoğlu", "ornek1@gmail.com", "", false, "", "", "SKNG", "parola2", "0587 123 45 67" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Kullanicilar");
        }
    }
}
