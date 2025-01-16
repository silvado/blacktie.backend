using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Updates3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductPricing_PaymentType_PaymentTypeId",
                schema: "blacktie",
                table: "ProductPricing");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductPricing_product_ProductId",
                schema: "blacktie",
                table: "ProductPricing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductPricing",
                schema: "blacktie",
                table: "ProductPricing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PaymentType",
                schema: "blacktie",
                table: "PaymentType");

            migrationBuilder.RenameTable(
                name: "ProductPricing",
                schema: "blacktie",
                newName: "product_pricing",
                newSchema: "blacktie");

            migrationBuilder.RenameTable(
                name: "PaymentType",
                schema: "blacktie",
                newName: "payment_type",
                newSchema: "blacktie");

            migrationBuilder.RenameColumn(
                name: "Price",
                schema: "blacktie",
                table: "product_pricing",
                newName: "price");

            migrationBuilder.RenameColumn(
                name: "Available",
                schema: "blacktie",
                table: "product_pricing",
                newName: "available");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "blacktie",
                table: "product_pricing",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedByUserId",
                schema: "blacktie",
                table: "product_pricing",
                newName: "update_by_user_id");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                schema: "blacktie",
                table: "product_pricing",
                newName: "update_at");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                schema: "blacktie",
                table: "product_pricing",
                newName: "product_id");

            migrationBuilder.RenameColumn(
                name: "PaymentTypeId",
                schema: "blacktie",
                table: "product_pricing",
                newName: "percent_type_id");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "blacktie",
                table: "product_pricing",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "DiscountPercent",
                schema: "blacktie",
                table: "product_pricing",
                newName: "discount_percent");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                schema: "blacktie",
                table: "product_pricing",
                newName: "deleted_by_user_id");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                schema: "blacktie",
                table: "product_pricing",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                schema: "blacktie",
                table: "product_pricing",
                newName: "created_by_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "blacktie",
                table: "product_pricing",
                newName: "created_at");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPricing_ProductId",
                schema: "blacktie",
                table: "product_pricing",
                newName: "IX_product_pricing_product_id");

            migrationBuilder.RenameIndex(
                name: "IX_ProductPricing_PaymentTypeId",
                schema: "blacktie",
                table: "product_pricing",
                newName: "IX_product_pricing_percent_type_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "blacktie",
                table: "payment_type",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                schema: "blacktie",
                table: "payment_type",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UpdatedByUserId",
                schema: "blacktie",
                table: "payment_type",
                newName: "update_by_user_id");

            migrationBuilder.RenameColumn(
                name: "UpdateAt",
                schema: "blacktie",
                table: "payment_type",
                newName: "update_at");

            migrationBuilder.RenameColumn(
                name: "IsDeleted",
                schema: "blacktie",
                table: "payment_type",
                newName: "is_deleted");

            migrationBuilder.RenameColumn(
                name: "DeletedByUserId",
                schema: "blacktie",
                table: "payment_type",
                newName: "deleted_by_user_id");

            migrationBuilder.RenameColumn(
                name: "DeleteAt",
                schema: "blacktie",
                table: "payment_type",
                newName: "deleted_at");

            migrationBuilder.RenameColumn(
                name: "CreatedByUserId",
                schema: "blacktie",
                table: "payment_type",
                newName: "created_by_user_id");

            migrationBuilder.RenameColumn(
                name: "CreatedAt",
                schema: "blacktie",
                table: "payment_type",
                newName: "created_at");

            migrationBuilder.RenameColumn(
                name: "CodeName",
                schema: "blacktie",
                table: "payment_type",
                newName: "code_name");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "blacktie",
                table: "product_pricing",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "update_by_user_id",
                schema: "blacktie",
                table: "product_pricing",
                type: "VARCHAR(100)",
                nullable: true,
                comment: "The id of the user who did the last modification",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                schema: "blacktie",
                table: "product_pricing",
                type: "timestamp",
                nullable: true,
                comment: "When this entity was modified the last time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "percent_type_id",
                schema: "blacktie",
                table: "product_pricing",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                schema: "blacktie",
                table: "product_pricing",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "The field that identifies that the entity was deleted",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "deleted_by_user_id",
                schema: "blacktie",
                table: "product_pricing",
                type: "VARCHAR(100)",
                nullable: true,
                comment: "The id of the user who did the delete",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                schema: "blacktie",
                table: "product_pricing",
                type: "timestamp",
                nullable: true,
                comment: "When this entity was deleted in this DB",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "created_by_user_id",
                schema: "blacktie",
                table: "product_pricing",
                type: "VARCHAR(100)",
                nullable: true,
                comment: "The id of the user who did create",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "blacktie",
                table: "product_pricing",
                type: "timestamp",
                nullable: false,
                comment: "When this entity was created in this DB",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AlterColumn<int>(
                name: "id",
                schema: "blacktie",
                table: "payment_type",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "update_by_user_id",
                schema: "blacktie",
                table: "payment_type",
                type: "VARCHAR(100)",
                nullable: true,
                comment: "The id of the user who did the last modification",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "update_at",
                schema: "blacktie",
                table: "payment_type",
                type: "timestamp",
                nullable: true,
                comment: "When this entity was modified the last time",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "is_deleted",
                schema: "blacktie",
                table: "payment_type",
                type: "boolean",
                nullable: false,
                defaultValue: false,
                comment: "The field that identifies that the entity was deleted",
                oldClrType: typeof(bool),
                oldType: "boolean");

            migrationBuilder.AlterColumn<string>(
                name: "deleted_by_user_id",
                schema: "blacktie",
                table: "payment_type",
                type: "VARCHAR(100)",
                nullable: true,
                comment: "The id of the user who did the delete",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "deleted_at",
                schema: "blacktie",
                table: "payment_type",
                type: "timestamp",
                nullable: true,
                comment: "When this entity was deleted in this DB",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "created_by_user_id",
                schema: "blacktie",
                table: "payment_type",
                type: "VARCHAR(100)",
                nullable: true,
                comment: "The id of the user who did create",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "created_at",
                schema: "blacktie",
                table: "payment_type",
                type: "timestamp",
                nullable: false,
                comment: "When this entity was created in this DB",
                oldClrType: typeof(DateTime),
                oldType: "timestamp with time zone");

            migrationBuilder.AddPrimaryKey(
                name: "PK_product_pricing",
                schema: "blacktie",
                table: "product_pricing",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_payment_type",
                schema: "blacktie",
                table: "payment_type",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "FK_product_pricing_payment_type_percent_type_id",
                schema: "blacktie",
                table: "product_pricing",
                column: "percent_type_id",
                principalSchema: "blacktie",
                principalTable: "payment_type",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_product_pricing_product_product_id",
                schema: "blacktie",
                table: "product_pricing",
                column: "product_id",
                principalSchema: "blacktie",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_product_pricing_payment_type_percent_type_id",
                schema: "blacktie",
                table: "product_pricing");

            migrationBuilder.DropForeignKey(
                name: "FK_product_pricing_product_product_id",
                schema: "blacktie",
                table: "product_pricing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_product_pricing",
                schema: "blacktie",
                table: "product_pricing");

            migrationBuilder.DropPrimaryKey(
                name: "PK_payment_type",
                schema: "blacktie",
                table: "payment_type");

            migrationBuilder.RenameTable(
                name: "product_pricing",
                schema: "blacktie",
                newName: "ProductPricing",
                newSchema: "blacktie");

            migrationBuilder.RenameTable(
                name: "payment_type",
                schema: "blacktie",
                newName: "PaymentType",
                newSchema: "blacktie");

            migrationBuilder.RenameColumn(
                name: "price",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "Price");

            migrationBuilder.RenameColumn(
                name: "available",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "Available");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "update_by_user_id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "UpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "update_at",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "product_id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "percent_type_id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "PaymentTypeId");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "discount_percent",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "DiscountPercent");

            migrationBuilder.RenameColumn(
                name: "deleted_by_user_id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "created_by_user_id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "CreatedAt");

            migrationBuilder.RenameIndex(
                name: "IX_product_pricing_product_id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "IX_ProductPricing_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_product_pricing_percent_type_id",
                schema: "blacktie",
                table: "ProductPricing",
                newName: "IX_ProductPricing_PaymentTypeId");

            migrationBuilder.RenameColumn(
                name: "name",
                schema: "blacktie",
                table: "PaymentType",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                schema: "blacktie",
                table: "PaymentType",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "update_by_user_id",
                schema: "blacktie",
                table: "PaymentType",
                newName: "UpdatedByUserId");

            migrationBuilder.RenameColumn(
                name: "update_at",
                schema: "blacktie",
                table: "PaymentType",
                newName: "UpdateAt");

            migrationBuilder.RenameColumn(
                name: "is_deleted",
                schema: "blacktie",
                table: "PaymentType",
                newName: "IsDeleted");

            migrationBuilder.RenameColumn(
                name: "deleted_by_user_id",
                schema: "blacktie",
                table: "PaymentType",
                newName: "DeletedByUserId");

            migrationBuilder.RenameColumn(
                name: "deleted_at",
                schema: "blacktie",
                table: "PaymentType",
                newName: "DeleteAt");

            migrationBuilder.RenameColumn(
                name: "created_by_user_id",
                schema: "blacktie",
                table: "PaymentType",
                newName: "CreatedByUserId");

            migrationBuilder.RenameColumn(
                name: "created_at",
                schema: "blacktie",
                table: "PaymentType",
                newName: "CreatedAt");

            migrationBuilder.RenameColumn(
                name: "code_name",
                schema: "blacktie",
                table: "PaymentType",
                newName: "CodeName");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "blacktie",
                table: "ProductPricing",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                schema: "blacktie",
                table: "ProductPricing",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true,
                oldComment: "The id of the user who did the last modification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                schema: "blacktie",
                table: "ProductPricing",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldComment: "When this entity was modified the last time");

            migrationBuilder.AlterColumn<int>(
                name: "PaymentTypeId",
                schema: "blacktie",
                table: "ProductPricing",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "blacktie",
                table: "ProductPricing",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false,
                oldComment: "The field that identifies that the entity was deleted");

            migrationBuilder.AlterColumn<string>(
                name: "DeletedByUserId",
                schema: "blacktie",
                table: "ProductPricing",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true,
                oldComment: "The id of the user who did the delete");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteAt",
                schema: "blacktie",
                table: "ProductPricing",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldComment: "When this entity was deleted in this DB");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                schema: "blacktie",
                table: "ProductPricing",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true,
                oldComment: "The id of the user who did create");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "blacktie",
                table: "ProductPricing",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldComment: "When this entity was created in this DB");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "blacktie",
                table: "PaymentType",
                type: "integer",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<string>(
                name: "UpdatedByUserId",
                schema: "blacktie",
                table: "PaymentType",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true,
                oldComment: "The id of the user who did the last modification");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateAt",
                schema: "blacktie",
                table: "PaymentType",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldComment: "When this entity was modified the last time");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "blacktie",
                table: "PaymentType",
                type: "boolean",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "boolean",
                oldDefaultValue: false,
                oldComment: "The field that identifies that the entity was deleted");

            migrationBuilder.AlterColumn<string>(
                name: "DeletedByUserId",
                schema: "blacktie",
                table: "PaymentType",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true,
                oldComment: "The id of the user who did the delete");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DeleteAt",
                schema: "blacktie",
                table: "PaymentType",
                type: "timestamp with time zone",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldNullable: true,
                oldComment: "When this entity was deleted in this DB");

            migrationBuilder.AlterColumn<string>(
                name: "CreatedByUserId",
                schema: "blacktie",
                table: "PaymentType",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true,
                oldComment: "The id of the user who did create");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedAt",
                schema: "blacktie",
                table: "PaymentType",
                type: "timestamp with time zone",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "timestamp",
                oldComment: "When this entity was created in this DB");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductPricing",
                schema: "blacktie",
                table: "ProductPricing",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PaymentType",
                schema: "blacktie",
                table: "PaymentType",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPricing_PaymentType_PaymentTypeId",
                schema: "blacktie",
                table: "ProductPricing",
                column: "PaymentTypeId",
                principalSchema: "blacktie",
                principalTable: "PaymentType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductPricing_product_ProductId",
                schema: "blacktie",
                table: "ProductPricing",
                column: "ProductId",
                principalSchema: "blacktie",
                principalTable: "product",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
