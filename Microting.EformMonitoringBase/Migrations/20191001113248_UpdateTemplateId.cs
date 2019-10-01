using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.EformMonitoringBase.Migrations
{
    public partial class UpdateTemplateId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "RuleVersions",
                newName: "CheckListId");

            migrationBuilder.RenameColumn(
                name: "TemplateId",
                table: "Rules",
                newName: "CheckListId");

            migrationBuilder.CreateIndex(
                name: "IX_Recipients_NotificationRuleId",
                table: "Recipients",
                column: "NotificationRuleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Recipients_Rules_NotificationRuleId",
                table: "Recipients",
                column: "NotificationRuleId",
                principalTable: "Rules",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Recipients_Rules_NotificationRuleId",
                table: "Recipients");

            migrationBuilder.DropIndex(
                name: "IX_Recipients_NotificationRuleId",
                table: "Recipients");

            migrationBuilder.RenameColumn(
                name: "CheckListId",
                table: "RuleVersions",
                newName: "TemplateId");

            migrationBuilder.RenameColumn(
                name: "CheckListId",
                table: "Rules",
                newName: "TemplateId");
        }
    }
}
