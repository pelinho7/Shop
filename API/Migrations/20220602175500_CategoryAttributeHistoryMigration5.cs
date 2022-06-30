using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CategoryAttributeHistoryMigration5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryAttributeHistories_AttributeId",
                table: "CategoryAttributeHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 585, DateTimeKind.Utc).AddTicks(7754),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 215, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1740),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(9332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2306),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(57));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3330),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2795),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6102),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5619),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6660),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5056),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3939),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(4570),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1012),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(8487));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttributeHistories_AttributeId",
                table: "CategoryAttributeHistories",
                column: "AttributeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryAttributeHistories_AttributeId",
                table: "CategoryAttributeHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 215, DateTimeKind.Utc).AddTicks(4717),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 585, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(9332),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(57),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1298),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(713),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4299),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3645),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4813),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3143),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1962),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(2546),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(8487),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1012));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttributeHistories_AttributeId",
                table: "CategoryAttributeHistories",
                column: "AttributeId",
                unique: true);
        }
    }
}
