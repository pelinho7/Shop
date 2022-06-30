using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CategoryAttributeHistoryMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryAttributeHistory_AttributeId",
                table: "CategoryAttributeHistory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 543, DateTimeKind.Utc).AddTicks(1616),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 515, DateTimeKind.Utc).AddTicks(3851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(5640),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(7599));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(6304),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(8116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(7336),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(9264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(6854),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(8728));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 545, DateTimeKind.Utc).AddTicks(73),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(1971));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(9557),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(1455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 545, DateTimeKind.Utc).AddTicks(596),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(9065),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(987));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(7982),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(9871));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(8540),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(475));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(4829),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(6794));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttributeHistory_AttributeId",
                table: "CategoryAttributeHistory",
                column: "AttributeId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_CategoryAttributeHistory_AttributeId",
                table: "CategoryAttributeHistory");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 515, DateTimeKind.Utc).AddTicks(3851),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 543, DateTimeKind.Utc).AddTicks(1616));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(7599),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(5640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(8116),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(6304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(9264),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(7336));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(8728),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(6854));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(1971),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 545, DateTimeKind.Utc).AddTicks(73));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(1455),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(9557));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistory",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 545, DateTimeKind.Utc).AddTicks(596));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(987),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(9065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(9871),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(7982));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 517, DateTimeKind.Utc).AddTicks(475),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(8540));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 24, 16, 39, 41, 516, DateTimeKind.Utc).AddTicks(6794),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 24, 16, 43, 36, 544, DateTimeKind.Utc).AddTicks(4829));

            migrationBuilder.CreateIndex(
                name: "IX_CategoryAttributeHistory_AttributeId",
                table: "CategoryAttributeHistory",
                column: "AttributeId");
        }
    }
}
