using Microsoft.EntityFrameworkCore.Migrations;

namespace HydroMajsterWebShopProject.Migrations
{
    public partial class Addingnewproduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt trzeci', 'Opis trzeciego produktu', 'https://i.wpimg.pl/O/644x406/d.wpimg.pl/1867929753--940256145/lech-walesa.jpg', '1000', 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
