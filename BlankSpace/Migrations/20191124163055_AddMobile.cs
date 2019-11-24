using Microsoft.EntityFrameworkCore.Migrations;

namespace BlankSpace.Migrations
{
    public partial class AddMobile : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "Mobile",
                table: "Agents",
                nullable: false,
                defaultValue: 0L);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mobile",
                table: "Agents");
        }
    }
}
