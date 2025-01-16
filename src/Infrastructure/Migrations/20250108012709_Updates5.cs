using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updates5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "date",
                schema: "blacktie",
                table: "order",
                newName: "payment_type_id");

            migrationBuilder.AddColumn<int>(
                name: "PaymentTypeId",
                schema: "blacktie",
                table: "order",
                type: "int",
                nullable: true);

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_payment_type_PaymentTypeId",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropIndex(
                name: "IX_order_PaymentTypeId",
                schema: "blacktie",
                table: "order");

            migrationBuilder.DropColumn(
                name: "PaymentTypeId",
                schema: "blacktie",
                table: "order");

            migrationBuilder.RenameColumn(
                name: "payment_type_id",
                schema: "blacktie",
                table: "order",
                newName: "date");
        }
    }
}
