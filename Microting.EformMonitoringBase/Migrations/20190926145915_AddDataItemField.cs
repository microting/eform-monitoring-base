using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.EformMonitoringBase.Migrations
{
    public partial class AddDataItemField : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "RuleVersions",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataItemId",
                table: "RuleVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleType",
                table: "RuleVersions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Data",
                table: "Rules",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DataItemId",
                table: "Rules",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RuleType",
                table: "Rules",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data",
                table: "RuleVersions");

            migrationBuilder.DropColumn(
                name: "DataItemId",
                table: "RuleVersions");

            migrationBuilder.DropColumn(
                name: "RuleType",
                table: "RuleVersions");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "DataItemId",
                table: "Rules");

            migrationBuilder.DropColumn(
                name: "RuleType",
                table: "Rules");
        }
    }
}
