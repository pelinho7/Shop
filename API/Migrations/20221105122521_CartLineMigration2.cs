using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CartLineMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5780),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(2467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 355, DateTimeKind.Utc).AddTicks(4896),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 755, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(11),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(554),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1707),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1122),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(7538),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(4465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8414),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9182),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(514),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8151),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8595),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9718),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6368),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1306),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1052),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6942),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(4529),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3954),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5128),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3474),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2371),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2936),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 356, DateTimeKind.Utc).AddTicks(9211),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(5539));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(2467),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5780));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 755, DateTimeKind.Utc).AddTicks(1792),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 355, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6389),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(11));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6963),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8177),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(7568),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(4465),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5411),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6214),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7718),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7451),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5092),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5677),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6759),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3184),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8470),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8170),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3829),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1233),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(707),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1807),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(34),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8851),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(9521),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(5539),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 356, DateTimeKind.Utc).AddTicks(9211));
        }
    }
}
