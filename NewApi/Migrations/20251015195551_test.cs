using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewApi.Migrations
{
    /// <inheritdoc />
    public partial class test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "cats");

            migrationBuilder.RenameColumn(
                name: "role",
                table: "cats",
                newName: "Last_Name");

            migrationBuilder.RenameColumn(
                name: "phone",
                table: "cats",
                newName: "First_Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Last_Name",
                table: "cats",
                newName: "role");

            migrationBuilder.RenameColumn(
                name: "First_Name",
                table: "cats",
                newName: "phone");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "cats",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
