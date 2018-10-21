using Microsoft.EntityFrameworkCore.Migrations;

namespace HydroMajsterWebShopProject.Migrations
{
    public partial class SampleData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\") values('Armatura sanitarna')");
            migrationBuilder.Sql("INSERT INTO \"Categories\" (\"Name\") values('Armatura grzewcza')");
            
            
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
