using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RISE.Entity.Migrations
{
    public partial class AddedMultiplePersonDetailSupport : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact");

            migrationBuilder.AddColumn<Guid>(
                name: "UUID",
                table: "PersonContact",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact",
                columns: new[] { "UUID", "PersonId" });

            migrationBuilder.CreateIndex(
                name: "IX_PersonContact_PersonId",
                table: "PersonContact",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact");

            migrationBuilder.DropIndex(
                name: "IX_PersonContact_PersonId",
                table: "PersonContact");

            migrationBuilder.DropColumn(
                name: "UUID",
                table: "PersonContact");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PersonContact",
                table: "PersonContact",
                column: "PersonId");
        }
    }
}
