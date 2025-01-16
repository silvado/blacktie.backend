using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "country",
                schema: "blacktie",
                table: "address");

            migrationBuilder.AddColumn<int>(
                name: "countryId",
                schema: "blacktie",
                table: "address",
                type: "int",
                maxLength: 50,
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_address_countryId",
                schema: "blacktie",
                table: "address",
                column: "countryId");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_address_country_countryId",
                schema: "blacktie",
                table: "address");

            migrationBuilder.DropIndex(
                name: "IX_address_countryId",
                schema: "blacktie",
                table: "address");

            migrationBuilder.DropColumn(
                name: "countryId",
                schema: "blacktie",
                table: "address");

            migrationBuilder.AddColumn<string>(
                name: "country",
                schema: "blacktie",
                table: "address",
                type: "character varying(50)",
                maxLength: 50,
                nullable: true);
        }
    }
}
