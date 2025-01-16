using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UnavailableDate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "unavailable_date",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    year = table.Column<int>(type: "integer", nullable: false),
                    start_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    end_at = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
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
                    table.PrimaryKey("PK_unavailable_date", x => x.id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "unavailable_date",
                schema: "blacktie");
        }
    }
}
