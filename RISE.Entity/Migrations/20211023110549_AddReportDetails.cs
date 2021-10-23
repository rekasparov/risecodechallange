using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RISE.Entity.Migrations
{
    public partial class AddReportDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.CreateTable(
            //    name: "ContactType",
            //    columns: table => new
            //    {
            //        UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_ContactType", x => x.UUID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Person",
            //    columns: table => new
            //    {
            //        UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Surname = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
            //        Company = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Person", x => x.UUID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "Report",
            //    columns: table => new
            //    {
            //        UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        RequestDate = table.Column<DateTime>(type: "datetime", nullable: false),
            //        Status = table.Column<bool>(type: "bit", nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Report", x => x.UUID);
            //    });

            //migrationBuilder.CreateTable(
            //    name: "PersonContact",
            //    columns: table => new
            //    {
            //        PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        ContactTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Content = table.Column<string>(type: "varchar(500)", unicode: false, maxLength: 500, nullable: false)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_PersonContact", x => new { x.PersonId, x.ContactTypeId });
            //        table.ForeignKey(
            //            name: "FK_PersonContact_ContactType_ContactTypeId",
            //            column: x => x.ContactTypeId,
            //            principalTable: "ContactType",
            //            principalColumn: "UUID",
            //            onDelete: ReferentialAction.Restrict);
            //        table.ForeignKey(
            //            name: "FK_PersonContact_Person_PersonId",
            //            column: x => x.PersonId,
            //            principalTable: "Person",
            //            principalColumn: "UUID",
            //            onDelete: ReferentialAction.Restrict);
            //    });

            migrationBuilder.CreateTable(
                name: "ReportDetail",
                columns: table => new
                {
                    ReportId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PersonCount = table.Column<int>(type: "int", nullable: false),
                    PhoneNumberCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportDetail", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_ReportDetail_Report_ReportId",
                        column: x => x.ReportId,
                        principalTable: "Report",
                        principalColumn: "UUID",
                        onDelete: ReferentialAction.Restrict);
                });

            //migrationBuilder.CreateIndex(
            //    name: "IX_PersonContact_ContactTypeId",
            //    table: "PersonContact",
            //    column: "ContactTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "PersonContact");

            migrationBuilder.DropTable(
                name: "ReportDetail");

            //migrationBuilder.DropTable(
            //    name: "ContactType");

            //migrationBuilder.DropTable(
            //    name: "Person");

            //migrationBuilder.DropTable(
            //    name: "Report");
        }
    }
}
