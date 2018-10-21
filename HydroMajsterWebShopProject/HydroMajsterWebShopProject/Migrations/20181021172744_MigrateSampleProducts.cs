using Microsoft.EntityFrameworkCore.Migrations;

namespace HydroMajsterWebShopProject.Migrations
{
    public partial class MigrateSampleProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(
                "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt pierwszy', 'Opis pierwszego produktu', 'http://t-eska.cdn.smcloud.net/regionalna/t/2/t/image/21cd19ee1cbd098fe3f5bc504097753acpVx7PwH-zdjd.jpg/ru-0-r-660,660-q-80-n-21cd19ee1cbd098fe3f5bc504097753acpVx7PwHzdjd.jpg', '123', 3)");
            migrationBuilder.Sql(
            "INSERT INTO \"Products\" (\"Name\", \"Description\", \"PhotoUrl\", \"Price\", \"CategoryId\") values('Produkt drugi', 'Opis drugiego produktu', 'http://t-eska.cdn.smcloud.net/regionalna/t/2/t/image/21cd19ee1cbd098fe3f5bc504097753acpVx7PwH-zdjd.jpg/ru-0-r-660,660-q-80-n-21cd19ee1cbd098fe3f5bc504097753acpVx7PwHzdjd.jpg', '1223', 4)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
