using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ProductUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_FromToId",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropForeignKey(
                name: "FK_product_from_to_form_id",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropIndex(
                name: "IX_product_FromToId",
                schema: "blacktie",
                table: "product");

            migrationBuilder.DropColumn(
                name: "FromToId",
                schema: "blacktie",
                table: "product");

            migrationBuilder.RenameColumn(
                name: "form_id",
                schema: "blacktie",
                table: "product",
                newName: "from_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_ToId",
                schema: "blacktie",
                table: "product",
                newName: "IX_product_to_id");

            migrationBuilder.RenameIndex(
                name: "IX_Product_FromId",
                schema: "blacktie",
                table: "product",
                newName: "IX_product_from_id");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.RenameColumn(
                name: "from_id",
                schema: "blacktie",
                table: "product",
                newName: "form_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_to_id",
                schema: "blacktie",
                table: "product",
                newName: "IX_Product_ToId");

            migrationBuilder.RenameIndex(
                name: "IX_product_from_id",
                schema: "blacktie",
                table: "product",
                newName: "IX_Product_FromId");

            migrationBuilder.AddColumn<int>(
                name: "FromToId",
                schema: "blacktie",
                table: "product",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_product_FromToId",
                schema: "blacktie",
                table: "product",
                column: "FromToId");

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_FromToId",
                schema: "blacktie",
                table: "product",
                column: "FromToId",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_from_to_form_id",
                schema: "blacktie",
                table: "product",
                column: "form_id",
                principalSchema: "blacktie",
                principalTable: "from_to",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
