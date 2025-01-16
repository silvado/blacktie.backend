using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddress2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_country_countryId",
                schema: "blacktie",
                table: "address");

            migrationBuilder.RenameColumn(
                name: "postar_code",
                schema: "blacktie",
                table: "address",
                newName: "postal_code");

            migrationBuilder.RenameColumn(
                name: "countryId",
                schema: "blacktie",
                table: "address",
                newName: "country_id");

            migrationBuilder.RenameIndex(
                name: "IX_address_countryId",
                schema: "blacktie",
                table: "address",
                newName: "IX_address_country_id");

            migrationBuilder.AddForeignKey(
                name: "FK_address_country_country_id",
                schema: "blacktie",
                table: "address",
                column: "country_id",
                principalSchema: "blacktie",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_country_country_id",
                schema: "blacktie",
                table: "address");

            migrationBuilder.RenameColumn(
                name: "postal_code",
                schema: "blacktie",
                table: "address",
                newName: "postar_code");

            migrationBuilder.RenameColumn(
                name: "country_id",
                schema: "blacktie",
                table: "address",
                newName: "countryId");

            migrationBuilder.RenameIndex(
                name: "IX_address_country_id",
                schema: "blacktie",
                table: "address",
                newName: "IX_address_countryId");

            migrationBuilder.AddForeignKey(
                name: "FK_address_country_countryId",
                schema: "blacktie",
                table: "address",
                column: "countryId",
                principalSchema: "blacktie",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
