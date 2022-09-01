using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ProductAmountMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(4310),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 368, DateTimeKind.Utc).AddTicks(3477),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 328, DateTimeKind.Utc).AddTicks(3289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(7651),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(8192),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(9302),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(50));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(8788),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(4843),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(4778));

            migrationBuilder.AlterColumn<double>(
                name: "Amount",
                table: "ProductAmounts",
                type: "REAL",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(3164),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(2552),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(3728),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(3617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(1559),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(9985),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(850),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(6929),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(7556));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(4276),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(4310));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 328, DateTimeKind.Utc).AddTicks(3289),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 368, DateTimeKind.Utc).AddTicks(3477));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8265),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(7651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8876),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(8192));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(50),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(9302));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(9457),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(8788));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(4778),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(4843));

            migrationBuilder.AlterColumn<decimal>(
                name: "Amount",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "REAL");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2965),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(3164));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2291),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(2552));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(3617),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(3728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1792),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(1559));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(712),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(9985));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1278),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 370, DateTimeKind.Utc).AddTicks(850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(7556),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 52, 18, 369, DateTimeKind.Utc).AddTicks(6929));
        }
    }
}
