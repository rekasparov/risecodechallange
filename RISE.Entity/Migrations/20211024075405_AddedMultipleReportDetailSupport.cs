using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RISE.Entity.Migrations
{
    public partial class AddedMultipleReportDetailSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportDetail",
                table: "ReportDetail");

            migrationBuilder.AddColumn<Guid>(
                name: "UUID",
                table: "ReportDetail",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportDetail",
                table: "ReportDetail",
                columns: new[] { "UUID", "ReportId" });

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetail_ReportId",
                table: "ReportDetail",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ReportDetail",
                table: "ReportDetail");

            migrationBuilder.DropIndex(
                name: "IX_ReportDetail_ReportId",
                table: "ReportDetail");

            migrationBuilder.DropColumn(
                name: "UUID",
                table: "ReportDetail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ReportDetail",
                table: "ReportDetail",
                column: "ReportId");
        }
    }
}
