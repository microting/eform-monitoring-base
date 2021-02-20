/*
The MIT License (MIT)

Copyright (c) 2007 - 2021 Microting A/S

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Microting.EformMonitoringBase.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //Setup for SQL Server Provider
            var appointmentAutoIdGenStrategy = "SqlServer:ValueGenerationStrategy";
            object appointmentAutoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;

            // Setup for MySQL Provider
            if (migrationBuilder.ActiveProvider == "Pomelo.EntityFrameworkCore.MySql")
            {
                DbConfig.IsMySQL = true;
                appointmentAutoIdGenStrategy = "MySql:ValueGenerationStrategy";
                appointmentAutoIdGenStrategyValue = MySqlValueGenerationStrategy.IdentityColumn;
            }
            migrationBuilder.CreateTable(
                name: "PluginConfigurationValues",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValues", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PluginConfigurationValueVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    Name = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PluginConfigurationValueVersions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recipients",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    Email = table.Column<string>(nullable: true),
                    NotificationRuleId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rules",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    TemplateId = table.Column<int>(),
                    Subject = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    AttachReport = table.Column<bool>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RuleVersions",
                columns: table => new
                {
                    Id = table.Column<int>()
                        .Annotation(appointmentAutoIdGenStrategy, appointmentAutoIdGenStrategyValue),
                    CreatedAt = table.Column<DateTime>(),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    WorkflowState = table.Column<string>(maxLength: 255, nullable: true),
                    CreatedByUserId = table.Column<int>(),
                    UpdatedByUserId = table.Column<int>(),
                    Version = table.Column<int>(),
                    TemplateId = table.Column<int>(),
                    Subject = table.Column<string>(nullable: true),
                    Text = table.Column<string>(nullable: true),
                    AttachReport = table.Column<bool>(),
                    NotificationRuleId = table.Column<int>()
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RuleVersions", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PluginConfigurationValues");

            migrationBuilder.DropTable(
                name: "PluginConfigurationValueVersions");

            migrationBuilder.DropTable(
                name: "Recipients");

            migrationBuilder.DropTable(
                name: "Rules");

            migrationBuilder.DropTable(
                name: "RuleVersions");
        }
    }
}
