using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CartMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(901),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 738, DateTimeKind.Utc).AddTicks(9607),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 874, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4901),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(1705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(5515),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6595),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6068),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2634),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3588),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(4429),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6109),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5844),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3239),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3866),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5267),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(5273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(1474),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6949),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6682),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2057),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9601),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9028),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(185),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(8516),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7354),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7924),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4103),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(940));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9998),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 874, DateTimeKind.Utc).AddTicks(4598),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 738, DateTimeKind.Utc).AddTicks(9607));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(1705),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4901));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(2483),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(5515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(4119),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6595));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(3378),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(6068));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(2106),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2634));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3434),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3588));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(4429));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6577),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6177),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3122),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3239));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3694),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(3866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(5273),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(5267));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(711),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(1474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7546),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6949));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7254),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(6682));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(1408),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(2057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(8380),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(7608),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(9028));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9152),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 741, DateTimeKind.Utc).AddTicks(185));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(6738),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(8516));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5325),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7354));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5957),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(7924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(940),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 11, 20, 740, DateTimeKind.Utc).AddTicks(4103));
        }
    }
}
