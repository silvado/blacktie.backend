using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CustomerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_country_country_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.DropForeignKey(
                name: "FK_customer_document_type_document_type_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_customer_country_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_customer_document_type_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.CreateIndex(
                name: "IX_customer_country_id",
                schema: "blacktie",
                table: "customer",
                column: "country_id");

            migrationBuilder.CreateIndex(
                name: "IX_customer_document_type_id",
                schema: "blacktie",
                table: "customer",
                column: "document_type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_customer_country_country_id",
                schema: "blacktie",
                table: "customer",
                column: "country_id",
                principalSchema: "blacktie",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_document_type_document_type_id",
                schema: "blacktie",
                table: "customer",
                column: "document_type_id",
                principalSchema: "blacktie",
                principalTable: "document_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_customer_country_country_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.DropForeignKey(
                name: "FK_customer_document_type_document_type_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_customer_country_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.DropIndex(
                name: "IX_customer_document_type_id",
                schema: "blacktie",
                table: "customer");

            migrationBuilder.CreateIndex(
                name: "IX_customer_country_id",
                schema: "blacktie",
                table: "customer",
                column: "country_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_customer_document_type_id",
                schema: "blacktie",
                table: "customer",
                column: "document_type_id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_country_country_id",
                schema: "blacktie",
                table: "customer",
                column: "country_id",
                principalSchema: "blacktie",
                principalTable: "country",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_customer_document_type_document_type_id",
                schema: "blacktie",
                table: "customer",
                column: "document_type_id",
                principalSchema: "blacktie",
                principalTable: "document_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
