using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updates4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "amount",
                schema: "blacktie",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "blacktie",
                table: "order",
                newName: "price");

            migrationBuilder.AlterColumn<int>(
                name: "price",
                schema: "blacktie",
                table: "order",
                type: "integer",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddColumn<float>(
                name: "Price",
                schema: "blacktie",
                table: "order",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "blacktie",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "blacktie",
                table: "order",
                newName: "Price");

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                schema: "blacktie",
                table: "order",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddColumn<int>(
                name: "amount",
                schema: "blacktie",
                table: "order",
                type: "integer",
                nullable: false,
                defaultValue: 0);
        }
    }
}
