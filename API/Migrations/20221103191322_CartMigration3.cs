using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CartMigration3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(530),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 537, DateTimeKind.Utc).AddTicks(9340),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 738, DateTimeKind.Utc).AddTicks(9607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(4455),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5075),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(5515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6264),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5627),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2304),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2634));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3176),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3997),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5651),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5340),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2913),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3504),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(4765),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1053),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6597),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6949));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6262),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1663),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9271),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8689),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9796),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(8516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6979),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(7563),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(3653),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4103));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(901),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 738, DateTimeKind.Utc).AddTicks(9607),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 537, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4901),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(5515),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6595),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6068),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2634),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3588),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(4429),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6109),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5844),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3239),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3866),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5267),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(1474),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6949),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6682),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2057),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9601),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9028),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(185),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(8516),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7354),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7924),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4103),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(3653));
        }
    }
}
