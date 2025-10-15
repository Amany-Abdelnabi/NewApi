using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NewApi.Migrations
{
    /// <inheritdoc />
    public partial class too : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_categories_categoryid",
                table: "items");

            migrationBuilder.DropColumn(
                name: "image",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "categoryid",
                table: "items",
                newName: "CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_items_categoryid",
                table: "items",
                newName: "IX_items_CategoryId");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "items",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "items",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "price",
                table: "items",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_items_categories_CategoryId",
                table: "items",
                column: "CategoryId",
                principalTable: "categories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_items_categories_CategoryId",
                table: "items");

            migrationBuilder.DropColumn(
                name: "price",
                table: "items");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "items",
                newName: "categoryid");

            migrationBuilder.RenameIndex(
                name: "IX_items_CategoryId",
                table: "items",
                newName: "IX_items_categoryid");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "items",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<int>(
                name: "categoryid",
                table: "items",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<byte[]>(
                name: "image",
                table: "items",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_items_categories_categoryid",
                table: "items",
                column: "categoryid",
                principalTable: "categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
