using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Product2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "product",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    price = table.Column<float>(type: "real", nullable: false),
                    form_id = table.Column<int>(type: "int", nullable: false),
                    to_id = table.Column<int>(type: "int", nullable: false),
                    transport_id = table.Column<Guid>(type: "uuid", nullable: false),
                    FromToId = table.Column<int>(type: "int", nullable: true),
                    created_by_user_id = table.Column<string>(type: "VARCHAR(100)", nullable: true, comment: "The id of the user who did create"),
                    created_at = table.Column<DateTime>(type: "timestamp", nullable: false, comment: "When this entity was created in this DB"),
                    update_at = table.Column<DateTime>(type: "timestamp", nullable: true, comment: "When this entity was modified the last time"),
                    update_by_user_id = table.Column<string>(type: "VARCHAR(100)", nullable: true, comment: "The id of the user who did the last modification"),
                    is_deleted = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false, comment: "The field that identifies that the entity was deleted"),
                    deleted_at = table.Column<DateTime>(type: "timestamp", nullable: true, comment: "When this entity was deleted in this DB"),
                    deleted_by_user_id = table.Column<string>(type: "VARCHAR(100)", nullable: true, comment: "The id of the user who did the delete")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.id);
                    table.ForeignKey(
                        name: "FK_product_from_to_FromToId",
                        column: x => x.FromToId,
                        principalSchema: "blacktie",
                        principalTable: "from_to",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK_product_from_to_form_id",
                        column: x => x.form_id,
                        principalSchema: "blacktie",
                        principalTable: "from_to",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_from_to_to_id",
                        column: x => x.to_id,
                        principalSchema: "blacktie",
                        principalTable: "from_to",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_product_transport_transport_id",
                        column: x => x.transport_id,
                        principalSchema: "blacktie",
                        principalTable: "transport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Product_FromId",
                schema: "blacktie",
                table: "product",
                column: "form_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_FromToId",
                schema: "blacktie",
                table: "product",
                column: "FromToId");

            migrationBuilder.CreateIndex(
                name: "IX_Product_ToId",
                schema: "blacktie",
                table: "product",
                column: "to_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_transport_id",
                schema: "blacktie",
                table: "product",
                column: "transport_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "product",
                schema: "blacktie");
        }
    }
}
