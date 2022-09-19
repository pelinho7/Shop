using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ProductMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(3260),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 210, DateTimeKind.Utc).AddTicks(2763),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 357, DateTimeKind.Utc).AddTicks(6797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(7132),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(7833),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(9117),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2832));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(8473),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(4926),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(5757),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(6438),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(7901),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(7654),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(5507),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(5975),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(7129),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(3850),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(4397),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(2175),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(1644),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(2650),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(1111),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(9775),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(350),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(6456),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(186));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6942),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(3260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 357, DateTimeKind.Utc).AddTicks(6797),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 210, DateTimeKind.Utc).AddTicks(2763));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(937),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(7132));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(1545),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(7833));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2832),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(9117));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2183),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(8473));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8673),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(4926));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9492),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(5757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(313),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(6438));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1757),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(7901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1445),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(7654));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9244),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(5507));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9774),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(5975));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(939),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(7129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(7536),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(3850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8124),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(4397));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5766),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(2175));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5256),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(1644));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6254),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(2650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4649),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(1111));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(3481),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(9775));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4106),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 212, DateTimeKind.Utc).AddTicks(350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(186),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 14, 24, 37, 211, DateTimeKind.Utc).AddTicks(6456));
        }
    }
}
