using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ParentCategoryAttributeMidration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 647, DateTimeKind.Utc).AddTicks(6662),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 585, DateTimeKind.Utc).AddTicks(7754));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(1579),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(2186),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2306));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(3425),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3330));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(2740),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2795));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(6393),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6102));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(5745),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5619));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(6965),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(5196),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5056));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(4115),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3939));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(4680),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(4570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(883),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1012));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 585, DateTimeKind.Utc).AddTicks(7754),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 647, DateTimeKind.Utc).AddTicks(6662));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1740),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(1579));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2306),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(2186));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3330),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(3425));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(2795),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(2740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6102),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(6393));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5619),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(5745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(6660),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(6965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(5056),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(5196));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(3939),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(4115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(4570),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(4680));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 6, 2, 17, 55, 0, 587, DateTimeKind.Utc).AddTicks(1012),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 6, 28, 16, 37, 57, 649, DateTimeKind.Utc).AddTicks(883));
        }
    }
}
