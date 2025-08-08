using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskFullStack.Migrations
{
    /// <inheritdoc />
    public partial class n2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Validated",
                table: "emailOTPs",
                newName: "IsValidated");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IsValidated",
                table: "emailOTPs",
                newName: "Validated");
        }
    }
}
