using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFullStack.Migrations
{
    /// <inheritdoc />
    public partial class n8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emailOTPs_Users_UserId",
                table: "emailOTPs");

            migrationBuilder.AddForeignKey(
                name: "FK_emailOTPs_Users_UserId",
                table: "emailOTPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_emailOTPs_Users_UserId",
                table: "emailOTPs");

            migrationBuilder.AddForeignKey(
                name: "FK_emailOTPs_Users_UserId",
                table: "emailOTPs",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "id");
        }
    }
}
