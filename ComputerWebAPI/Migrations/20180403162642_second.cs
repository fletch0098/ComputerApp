using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ComputerWebAPI.Migrations
{
    public partial class second : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Memory",
                table: "Computer");

            migrationBuilder.AddColumn<int>(
                name: "MemoryId",
                table: "Computer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "MemoryId1",
                table: "Computer",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Memory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Brand = table.Column<string>(nullable: true),
                    LastModified = table.Column<DateTime>(nullable: false),
                    SizeGb = table.Column<int>(nullable: false),
                    Speed = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Memory", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Computer_MemoryId1",
                table: "Computer",
                column: "MemoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_Memory_MemoryId1",
                table: "Computer",
                column: "MemoryId1",
                principalTable: "Memory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_Memory_MemoryId1",
                table: "Computer");

            migrationBuilder.DropTable(
                name: "Memory");

            migrationBuilder.DropIndex(
                name: "IX_Computer_MemoryId1",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "MemoryId",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "MemoryId1",
                table: "Computer");

            migrationBuilder.AddColumn<string>(
                name: "Memory",
                table: "Computer",
                nullable: true);
        }
    }
}
