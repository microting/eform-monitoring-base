using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.EformMonitoringBase.Migrations
{
    public partial class AddingNewAttributes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AttachLink",
                table: "Rules",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeValue",
                table: "Rules",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachLink",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "IncludeValue",
                table: "Rules");
        }
    }
}
