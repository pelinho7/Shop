using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CartMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9998),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 874, DateTimeKind.Utc).AddTicks(4598),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 920, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(1705),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(2483),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(4119),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(3378),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(2106),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3434),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6577),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6177),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3122),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3694),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(5273),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(711),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7546),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7254),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(1408),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(8380),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9094));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(7608),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9152),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(6738),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5325),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5957),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(940),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3166));

            migrationBuilder.CreateTable(
                name: "Carts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Carts", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Carts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9998));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 920, DateTimeKind.Utc).AddTicks(8994),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 874, DateTimeKind.Utc).AddTicks(4598));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3963),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(1705));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(4826),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6183),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(4119));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(5593),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(3378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2047),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(2106));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3115),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3434));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4075),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5740),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5422),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(6177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2850),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3122));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3577),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(3694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4724),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(5273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(891),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(711));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6545),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6220),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(7254));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(1494),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 877, DateTimeKind.Utc).AddTicks(1408));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9094),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(8380));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8570),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(7608));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9601),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(9152));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8010),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(6738));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6868),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(7443),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(5957));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3166),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 18, 51, 11, 876, DateTimeKind.Utc).AddTicks(940));
        }
    }
}
