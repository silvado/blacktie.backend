using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Order : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    product_id = table.Column<Guid>(type: "uuid", nullable: false),
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    total_smallbags = table.Column<int>(type: "integer", nullable: false),
                    total_bigbags = table.Column<int>(type: "integer", nullable: false),
                    total_passengers = table.Column<int>(type: "integer", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
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
                    table.PrimaryKey("PK_order", x => x.id);
                    table.ForeignKey(
                        name: "FK_order_customer_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "blacktie",
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_order_product_product_id",
                        column: x => x.product_id,
                        principalSchema: "blacktie",
                        principalTable: "product",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_order_customer_id",
                schema: "blacktie",
                table: "order",
                column: "customer_id");

            migrationBuilder.CreateIndex(
                name: "IX_order_product_id",
                schema: "blacktie",
                table: "order",
                column: "product_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order",
                schema: "blacktie");
        }
    }
}
