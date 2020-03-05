using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.EformMonitoringBase.Migrations
{
    public partial class AddingAttributesToNotificationRuleVersions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "AttachLink",
                table: "RuleVersions",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IncludeValue",
                table: "RuleVersions",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AttachLink",
                table: "RuleVersions");

            migrationBuilder.DropColumn(
                name: "IncludeValue",
                table: "RuleVersions");
        }
    }
}
