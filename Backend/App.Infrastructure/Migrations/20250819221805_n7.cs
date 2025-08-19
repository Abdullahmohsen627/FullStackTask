using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFullStack.Migrations
{
    /// <inheritdoc />
    public partial class n7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "UserId",
                table: "emailOTPs",
                type: "uniqueidentifier",
                nullable: false);

            migrationBuilder.CreateIndex(
                name: "IX_emailOTPs_UserId",
                table: "emailOTPs",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_emailOTPs_Users_UserId",
                table: "emailOTPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete:ReferentialAction.Cascade
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emailOTPs_Users_UserId",
                table: "emailOTPs");

            migrationBuilder.DropIndex(
                name: "IX_emailOTPs_UserId",
                table: "emailOTPs");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "emailOTPs");
        }
    }
}
