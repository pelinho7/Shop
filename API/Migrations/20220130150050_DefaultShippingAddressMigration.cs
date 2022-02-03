using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DefaultShippingAddressMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 933, DateTimeKind.Utc).AddTicks(5441),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 330, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 934, DateTimeKind.Utc).AddTicks(9136),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 934, DateTimeKind.Utc).AddTicks(9721),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 935, DateTimeKind.Utc).AddTicks(726),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(8655));

            migrationBuilder.AddColumn<bool>(
                name: "Default",
                table: "ShippingAddressHistories",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 935, DateTimeKind.Utc).AddTicks(213),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.AddColumn<bool>(
                name: "Default",
                table: "ShippingAddresses",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 934, DateTimeKind.Utc).AddTicks(8519),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(6321));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Default",
                table: "ShippingAddressHistories");

            migrationBuilder.DropColumn(
                name: "Default",
                table: "ShippingAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 330, DateTimeKind.Utc).AddTicks(3136),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 933, DateTimeKind.Utc).AddTicks(5441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7022),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 934, DateTimeKind.Utc).AddTicks(9136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7546),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 934, DateTimeKind.Utc).AddTicks(9721));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(8655),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 935, DateTimeKind.Utc).AddTicks(726));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(8160),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 935, DateTimeKind.Utc).AddTicks(213));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(6321),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 30, 15, 0, 49, 934, DateTimeKind.Utc).AddTicks(8519));
        }
    }
}
