using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ComputerWebAPI.Migrations
{
    public partial class MemoryWorking : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_Memory_MemoryId",
                table: "Computer");

            migrationBuilder.AlterColumn<long>(
                name: "MemoryId",
                table: "Computer",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_Memory_MemoryId",
                table: "Computer",
                column: "MemoryId",
                principalTable: "Memory",
                principalColumn: "MemoryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_Memory_MemoryId",
                table: "Computer");

            migrationBuilder.AlterColumn<long>(
                name: "MemoryId",
                table: "Computer",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_Memory_MemoryId",
                table: "Computer",
                column: "MemoryId",
                principalTable: "Memory",
                principalColumn: "MemoryId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
