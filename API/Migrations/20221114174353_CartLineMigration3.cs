using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CartLineMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(4575),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5780));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 851, DateTimeKind.Utc).AddTicks(9444),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 355, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(8301),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(11));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(8848),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(554));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(5),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(9475),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(6435),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(7538));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(7268),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8414));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(7988),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9182));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(9398),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(514));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(9141),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(269));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(6970),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(7445),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(8527),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(5238),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6368));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 855, DateTimeKind.Utc).AddTicks(129),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(9886),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1052));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(5808),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6942));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(2992),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(4529));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(2426),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(3530),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5128));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(1768),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(697),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2371));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(1214),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2936));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(7502),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 356, DateTimeKind.Utc).AddTicks(9211));

            migrationBuilder.AddForeignKey(
                name: "FK_Photos_CartLines_ProductId",
                table: "Photos",
                column: "ProductId",
                principalTable: "CartLines",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photos_CartLines_ProductId",
                table: "Photos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5780),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(4575));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 355, DateTimeKind.Utc).AddTicks(4896),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 851, DateTimeKind.Utc).AddTicks(9444));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(11),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(8301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(554),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(8848));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1707),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(5));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(1122),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(9475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(7538),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(6435));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8414),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(7268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9182),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(7988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(514),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(9398));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(269),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(9141));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8151),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(6970));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(8595),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(7445));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(9718),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(8527));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6368),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(5238));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1306),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 855, DateTimeKind.Utc).AddTicks(129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 358, DateTimeKind.Utc).AddTicks(1052),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(9886));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(6942),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(5808));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(4529),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(2992));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3954),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(2426));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(5128),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(3530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(3474),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(1768));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2371),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(697));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 357, DateTimeKind.Utc).AddTicks(2936),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 854, DateTimeKind.Utc).AddTicks(1214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 5, 12, 25, 21, 356, DateTimeKind.Utc).AddTicks(9211),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 14, 17, 43, 52, 853, DateTimeKind.Utc).AddTicks(7502));
        }
    }
}
