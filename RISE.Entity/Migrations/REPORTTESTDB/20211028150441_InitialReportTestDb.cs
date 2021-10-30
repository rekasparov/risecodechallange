using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RISE.Entity.Migrations.REPORTTESTDB
{
    public partial class InitialReportTestDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Report",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp", nullable: false),
                    Status = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Report", x => x.UUID);
                });

            migrationBuilder.CreateTable(
                name: "ReportDetail",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uuid", nullable: false),
                    ReportId = table.Column<Guid>(type: "uuid", nullable: false),
                    Location = table.Column<string>(type: "character varying(100)", unicode: false, maxLength: 100, nullable: false),
                    PersonCount = table.Column<int>(type: "integer", nullable: false),
                    PhoneNumberCount = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetail", x => new { x.UUID, x.ReportId });
                    table.ForeignKey(
                        name: "FK_ReportDetail_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReportDetail_ReportId",
                table: "ReportDetail",
                column: "ReportId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReportDetail");

            migrationBuilder.DropTable(
                name: "Report");
        }
    }
}
