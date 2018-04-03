using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace ComputerWebAPI.Migrations
{
    public partial class CreateMemory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Memory",
                newName: "MemoryId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Computer",
                newName: "ComputerId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "MemoryId",
                table: "Memory",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ComputerId",
                table: "Computer",
                newName: "Id");
        }
    }
}
