using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updates6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_payment_type_PaymentTypeId",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_product_pricing_payment_type_percent_type_id",
                schema: "blacktie",
                table: "product_pricing");

            migrationBuilder.DropIndex(
                name: "IX_order_PaymentTypeId",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropColumn(
                name: "Price",
                schema: "blacktie",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "percent_type_id",
                schema: "blacktie",
                table: "product_pricing",
                newName: "payment_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_pricing_percent_type_id",
                schema: "blacktie",
                table: "product_pricing",
                newName: "IX_product_pricing_payment_type_id");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "blacktie",
                table: "order",
                newName: "amount");

            migrationBuilder.RenameColumn(
                name: "payment_type_id",
                schema: "blacktie",
                table: "order",
                newName: "date");

            migrationBuilder.AddForeignKey(
                name: "FK_product_pricing_payment_type_payment_type_id",
                schema: "blacktie",
                table: "product_pricing",
                column: "payment_type_id",
                principalSchema: "blacktie",
                principalTable: "payment_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_pricing_payment_type_payment_type_id",
                schema: "blacktie",
                table: "product_pricing");

            migrationBuilder.RenameColumn(
                name: "payment_type_id",
                schema: "blacktie",
                table: "product_pricing",
                newName: "percent_type_id");

            migrationBuilder.RenameIndex(
                name: "IX_product_pricing_payment_type_id",
                schema: "blacktie",
                table: "product_pricing",
                newName: "IX_product_pricing_percent_type_id");

            migrationBuilder.RenameColumn(
                name: "date",
                schema: "blacktie",
                table: "order",
                newName: "payment_type_id");

            migrationBuilder.RenameColumn(
                name: "amount",
                schema: "blacktie",
                table: "order",
                newName: "price");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                schema: "blacktie",
                table: "order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                schema: "blacktie",
                table: "order",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_order_PaymentTypeId",
                schema: "blacktie",
                table: "order",
                column: "PaymentTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_order_payment_type_PaymentTypeId",
                schema: "blacktie",
                table: "order",
                column: "PaymentTypeId",
                principalSchema: "blacktie",
                principalTable: "payment_type",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_pricing_payment_type_percent_type_id",
                schema: "blacktie",
                table: "product_pricing",
                column: "percent_type_id",
                principalSchema: "blacktie",
                principalTable: "payment_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
