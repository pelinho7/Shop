using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ProductHistoryMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4016),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(4088));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 718, DateTimeKind.Utc).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 736, DateTimeKind.Utc).AddTicks(5187));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8129),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(8683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8736),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(9289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9924),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9402),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(9795));

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "ProductHistories",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "ProductHistories",
                type: "REAL",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4606),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(4636));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(5109),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(5105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2828),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(2946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2326),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(2484));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(3363),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(3520));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1713),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(1977));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(505),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1124),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(1468));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(7294),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(8060));

            migrationBuilder.CreateIndex(
                name: "IX_ProductHistories_CategoryId",
                table: "ProductHistories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductHistories_Categories_CategoryId",
                table: "ProductHistories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductHistories_Categories_CategoryId",
                table: "ProductHistories");

            migrationBuilder.DropIndex(
                name: "IX_ProductHistories_CategoryId",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "ProductHistories");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "ProductHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(4088),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 736, DateTimeKind.Utc).AddTicks(5187),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 718, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(8683),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(9289),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(322),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(9795),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(4636),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(5105),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(2946),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(2484),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(3520),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(3363));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(1977),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(939),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 738, DateTimeKind.Utc).AddTicks(1468),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 2, 10, 41, 18, 737, DateTimeKind.Utc).AddTicks(8060),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(7294));
        }
    }
}
