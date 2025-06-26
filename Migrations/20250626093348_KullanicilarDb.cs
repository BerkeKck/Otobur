using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Otobur.Migrations
{
    /// <inheritdoc />
    public partial class KullanicilarDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Kullanicilar",
                columns: new[] { "KullaniciNumarasi", "Eposta", "GorebilecegiTablolar", "KayitSilebilme", "KayitYapabilecegiTablolar", "KullaniciAdi", "KullaniciGrubu", "KullaniciKodu", "Parola", "Telefon" },
                values: new object[,]
                {
                    { "1", "", "Tüm Tablolar", true, "Tüm Tablolar", "Salih Kanoğlu", "Sistem Yöneticisi", "", "1234", "" },
                    { "2", "", "Toplayıcı Defteri, Herbaryum Tablosu", false, "Toplayıcı Defteri, Herbaryum Tablosu", "Adil Güner", "Normal Kullanıcı", "", "5678", "" },
                    { "3", "", "Aksesyon Tablosu, Tohum Bankası Tablosu, Bitki Durum Tablosu", false, "Aksesyon Tablosu, Tohum Bankası Tablosu, Bitki Durum Tablosu", "Ali Çelik", "Normal Kullanıcı", "", "9876", "" },
                    { "4", "", "Sadece Kayıtları Görebilir", false, "Kayıt Yapamaz", "Osman Tek", "Eğitimde", "", "2468", "" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "KullaniciNumarasi",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "KullaniciNumarasi",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "KullaniciNumarasi",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Kullanicilar",
                keyColumn: "KullaniciNumarasi",
                keyValue: "4");
        }
    }
}
