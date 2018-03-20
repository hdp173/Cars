using Microsoft.EntityFrameworkCore.Migrations;

namespace MyCars.Migrations
{
    public partial class deletemakeswithoutmodels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("delete from makes where id not in (select makeid from models)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
