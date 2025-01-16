using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateVariations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "number_passengers",
                schema: "blacktie",
                table: "transport_variation",
                newName: "small_bags");

            migrationBuilder.RenameColumn(
                name: "number_bag",
                schema: "blacktie",
                table: "transport_variation",
                newName: "passengers");

            migrationBuilder.AddColumn<int>(
                name: "big_bags",
                schema: "blacktie",
                table: "transport_variation",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "big_bags",
                schema: "blacktie",
                table: "transport_variation");

            migrationBuilder.RenameColumn(
                name: "small_bags",
                schema: "blacktie",
                table: "transport_variation",
                newName: "number_passengers");

            migrationBuilder.RenameColumn(
                name: "passengers",
                schema: "blacktie",
                table: "transport_variation",
                newName: "number_bag");
        }
    }
}
