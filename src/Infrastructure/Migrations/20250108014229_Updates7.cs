using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updates7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "payment_type_id",
                schema: "blacktie",
                table: "order",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<float>(
                name: "price",
                schema: "blacktie",
                table: "order",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateIndex(
                name: "IX_order_payment_type_id",
                schema: "blacktie",
                table: "order",
                column: "payment_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_order_payment_type_payment_type_id",
                schema: "blacktie",
                table: "order",
                column: "payment_type_id",
                principalSchema: "blacktie",
                principalTable: "payment_type",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_payment_type_payment_type_id",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_payment_type_id",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropColumn(
                name: "payment_type_id",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropColumn(
                name: "price",
                schema: "blacktie",
                table: "order");
        }
    }
}
