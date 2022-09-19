using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DiscountMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(7891),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(2053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 400, DateTimeKind.Utc).AddTicks(9708),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 568, DateTimeKind.Utc).AddTicks(2842));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(2750),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(6415));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(3245),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(6913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(4276),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(3809),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(7524));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(8341),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(2505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(8836),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(3005));

            migrationBuilder.AddColumn<bool>(
                name: "Deleted",
                table: "Discounts",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(6824),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(950));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(6318),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(260));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(7319),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(1458));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(5866),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(9611));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(4900),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(8635));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(5366),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(9104));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(2081),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(5726));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Deleted",
                table: "Discounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(2053),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(7891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 568, DateTimeKind.Utc).AddTicks(2842),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 400, DateTimeKind.Utc).AddTicks(9708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(6415),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(2750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(6913),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(3245));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(8007),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(7524),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(3809));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(2505),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(8341));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(3005),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(8836));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(950),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(6824));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(260),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(6318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 570, DateTimeKind.Utc).AddTicks(1458),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(7319));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(9611),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(5866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(8635),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(9104),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(5366));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 1, 17, 12, 43, 569, DateTimeKind.Utc).AddTicks(5726),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 1, 17, 22, 16, 402, DateTimeKind.Utc).AddTicks(2081));
        }
    }
}
