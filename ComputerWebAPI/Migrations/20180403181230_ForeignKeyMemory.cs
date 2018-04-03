using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ComputerWebAPI.Migrations
{
    public partial class ForeignKeyMemory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_Memory_MemoryId1",
                table: "Computer");

            migrationBuilder.DropIndex(
                name: "IX_Computer_MemoryId1",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "MemoryId1",
                table: "Computer");

            migrationBuilder.AlterColumn<long>(
                name: "MemoryId",
                table: "Computer",
                nullable: false,
                oldClrType: typeof(int));

            migrationBuilder.CreateIndex(
                name: "IX_Computer_MemoryId",
                table: "Computer",
                column: "MemoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_Memory_MemoryId",
                table: "Computer",
                column: "MemoryId",
                principalTable: "Memory",
                principalColumn: "MemoryId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_Memory_MemoryId",
                table: "Computer");

            migrationBuilder.DropIndex(
                name: "IX_Computer_MemoryId",
                table: "Computer");

            migrationBuilder.AlterColumn<int>(
                name: "MemoryId",
                table: "Computer",
                nullable: false,
                oldClrType: typeof(long));

            migrationBuilder.AddColumn<long>(
                name: "MemoryId1",
                table: "Computer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computer_MemoryId1",
                table: "Computer",
                column: "MemoryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_Memory_MemoryId1",
                table: "Computer",
                column: "MemoryId1",
                principalTable: "Memory",
                principalColumn: "MemoryId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
