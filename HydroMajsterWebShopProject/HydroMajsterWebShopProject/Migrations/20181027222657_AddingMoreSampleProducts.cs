using Microsoft.EntityFrameworkCore.Migrations;

namespace HydroMajsterWebShopProject.Migrations
{
    public partial class AddingMoreSampleProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt czwarty', 'Opis czwartego produktu', 'https://i.wpimg.pl/O/644x406/d.wpimg.pl/1867929753--940256145/lech-walesa.jpg', '1000', 4)");
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt piaty', 'Opis piatego produktu', 'https://eloblog.pl/wp-content/uploads/2015/10/Monkey-selfie.jpg', '1000', 3)");
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt szosty', 'Opis szostego produktu', 'https://i.wpimg.pl/O/644x406/d.wpimg.pl/1867929753--940256145/lech-walesa.jpg', '1000', 4)");
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt siodmy', 'Opis siodmego produktu', 'https://eloblog.pl/wp-content/uploads/2015/10/Monkey-selfie.jpg', '1000', 3)");
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt osmy', 'Opis osmego produktu', 'http://bi.gazeta.pl/im/d7/e1/15/z22942167Q,Popek.jpg', '1000', 4)");
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt dziewiaty', 'Opis dziewiatego produktu', 'https://i.wpimg.pl/O/644x406/d.wpimg.pl/1867929753--940256145/lech-walesa.jpg', '1000', 3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
