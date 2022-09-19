using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ProductAttributeHistoryMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6942),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 357, DateTimeKind.Utc).AddTicks(6797),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 336, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(937),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(735));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(1545),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2832),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2183),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8673),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(8565));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9492),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9452));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(313),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 339, DateTimeKind.Utc).AddTicks(91));

            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1757),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1445),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9244),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9085));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9774),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9634));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(939),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 339, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(7536),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8124),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5766),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5256),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6254),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4649),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(4474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(3481),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4106),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(186),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(62));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductTextAttributeHistories");

            migrationBuilder.DropColumn(
                name: "Value",
                table: "ProductNumberAttributeHistories");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6851),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 336, DateTimeKind.Utc).AddTicks(6242),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 357, DateTimeKind.Utc).AddTicks(6797));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(735),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(937));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(1545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2688),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2832));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2014),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(2183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(8565),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8673));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9452),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9492));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 339, DateTimeKind.Utc).AddTicks(91),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(313));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1757));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(1445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9085),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9244));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9634),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(9774));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 339, DateTimeKind.Utc).AddTicks(660),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 360, DateTimeKind.Utc).AddTicks(939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7378),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(7536));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(8124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5624),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5766));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5116),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(5256));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6255),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(6254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(4474),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4649));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3389),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(3481));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3983),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(4106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(62),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 14, 10, 6, 6, 359, DateTimeKind.Utc).AddTicks(186));
        }
    }
}
