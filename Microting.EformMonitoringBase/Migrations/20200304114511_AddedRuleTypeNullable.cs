using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.EformMonitoringBase.Migrations
{
    public partial class AddedRuleTypeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RuleType",
                table: "RuleVersions",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "RuleType",
                table: "Rules",
                nullable: true,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "RuleType",
                table: "RuleVersions",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "RuleType",
                table: "Rules",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
