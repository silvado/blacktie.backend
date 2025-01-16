using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialState : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "blacktie");

            migrationBuilder.CreateTable(
                name: "address",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    street = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    number = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    complement = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    locality = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    city = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    region_code = table.Column<string>(type: "character varying(5)", maxLength: 5, nullable: true),
                    country = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    postar_code = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_address", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Audits",
                schema: "blacktie",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: true),
                    UserName = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    TableName = table.Column<string>(type: "text", nullable: true),
                    DateTime = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    OldValues = table.Column<string>(type: "text", nullable: true),
                    NewValues = table.Column<string>(type: "text", nullable: true),
                    AffectedColumns = table.Column<string>(type: "text", nullable: true),
                    PrimaryKey = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Audits", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "control",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    user_id = table.Column<Guid>(type: "uuid", nullable: false),
                    control_number = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    expire_at = table.Column<DateTime>(type: "timestamp", nullable: false),
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
                    table.PrimaryKey("PK_control", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "country",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    calling_code = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_country", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "document_type",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_document_type", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "from_to",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
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
                    table.PrimaryKey("PK_from_to", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "transport",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    brand = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    model = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    image = table.Column<string>(type: "TEXT", nullable: true),
                    youtube_link = table.Column<string>(type: "text", nullable: true),
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
                    table.PrimaryKey("PK_transport", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "user",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    password = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
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
                    table.PrimaryKey("PK_user", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "customer",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    tax_id = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    country_id = table.Column<int>(type: "int", nullable: false),
                    document_type_id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    phone = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
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
                    table.PrimaryKey("PK_customer", x => x.id);
                    table.ForeignKey(
                        name: "FK_customer_country_country_id",
                        column: x => x.country_id,
                        principalSchema: "blacktie",
                        principalTable: "country",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_customer_document_type_document_type_id",
                        column: x => x.document_type_id,
                        principalSchema: "blacktie",
                        principalTable: "document_type",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "transport_variation",
                schema: "blacktie",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    transport_id = table.Column<Guid>(type: "uuid", nullable: false),
                    number_bag = table.Column<int>(type: "int", nullable: false),
                    number_passengers = table.Column<int>(type: "int", nullable: false),
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
                    table.PrimaryKey("PK_transport_variation", x => x.id);
                    table.ForeignKey(
                        name: "FK_transport_variation_transport_transport_id",
                        column: x => x.transport_id,
                        principalSchema: "blacktie",
                        principalTable: "transport",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "customer_address",
                schema: "blacktie",
                columns: table => new
                {
                    customer_id = table.Column<Guid>(type: "uuid", nullable: false),
                    address_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customer_address", x => new { x.customer_id, x.address_id });
                    table.ForeignKey(
                        name: "FK_customer_address_address_address_id",
                        column: x => x.address_id,
                        principalSchema: "blacktie",
                        principalTable: "address",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_customer_address_customer_customer_id",
                        column: x => x.customer_id,
                        principalSchema: "blacktie",
                        principalTable: "customer",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_customer_address_address_id",
                schema: "blacktie",
                table: "customer_address",
                column: "address_id");

            migrationBuilder.CreateIndex(
                name: "IX_transport_variation_transport_id",
                schema: "blacktie",
                table: "transport_variation",
                column: "transport_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Audits",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "control",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "customer_address",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "from_to",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "transport_variation",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "user",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "address",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "customer",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "transport",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "country",
                schema: "blacktie");

            migrationBuilder.DropTable(
                name: "document_type",
                schema: "blacktie");
        }
    }
}
