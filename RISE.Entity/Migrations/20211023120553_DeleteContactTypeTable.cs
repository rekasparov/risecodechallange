using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RISE.Entity.Migrations
{
    public partial class DeleteContactTypeTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonContact_ContactType_ContactTypeId",
                table: "PersonContact");

            migrationBuilder.DropTable(
                name: "ContactType");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact");

            //migrationBuilder.DropIndex(
            //    name: "IX_PersonContact_ContactTypeId",
            //    table: "PersonContact");

            migrationBuilder.DropColumn(
                name: "ContactTypeId",
                table: "PersonContact");

            migrationBuilder.DropColumn(
                name: "Content",
                table: "PersonContact");

            migrationBuilder.AddColumn<string>(
                name: "EmailAddress",
                table: "PersonContact",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "PersonContact",
                type: "varchar(100)",
                unicode: false,
                maxLength: 100,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "PersonContact",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact");

            migrationBuilder.DropColumn(
                name: "EmailAddress",
                table: "PersonContact");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "PersonContact");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "PersonContact");

            migrationBuilder.AddColumn<Guid>(
                name: "ContactTypeId",
                table: "PersonContact",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "Content",
                table: "PersonContact",
                type: "varchar(500)",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact",
                columns: new[] { "PersonId", "ContactTypeId" });

            migrationBuilder.CreateTable(
                name: "ContactType",
                columns: table => new
                {
                    UUID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactType", x => x.UUID);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_ContactTypeId",
                table: "PersonContact",
                column: "ContactTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonContact_ContactType_ContactTypeId",
                table: "PersonContact",
                column: "ContactTypeId",
                principalTable: "ContactType",
                principalColumn: "UUID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
