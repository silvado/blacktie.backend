using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductUpdate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_FromId1",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_ToId1",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_from_id",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_to_id",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_FromId1",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_ToId1",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropColumn(
                name: "FromId1",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropColumn(
                name: "ToId1",
                schema: "blacktie",
                table: "product");

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_from_id",
                schema: "blacktie",
                table: "product",
                column: "from_id",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_to_id",
                schema: "blacktie",
                table: "product",
                column: "to_id",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_from_id",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_to_id",
                schema: "blacktie",
                table: "product");

            migrationBuilder.AddColumn<int>(
                name: "FromId1",
                schema: "blacktie",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ToId1",
                schema: "blacktie",
                table: "product",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_product_FromId1",
                schema: "blacktie",
                table: "product",
                column: "FromId1");

            migrationBuilder.CreateIndex(
                name: "IX_product_ToId1",
                schema: "blacktie",
                table: "product",
                column: "ToId1");

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_FromId1",
                schema: "blacktie",
                table: "product",
                column: "FromId1",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_ToId1",
                schema: "blacktie",
                table: "product",
                column: "ToId1",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_from_id",
                schema: "blacktie",
                table: "product",
                column: "from_id",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_to_id",
                schema: "blacktie",
                table: "product",
                column: "to_id",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
