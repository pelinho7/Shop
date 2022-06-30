using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CategoryAttributeHistoryMigration4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributeHistory_Attributes_AttributeId",
                table: "CategoryAttributeHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributeHistory_CategoryAttributes_CategoryAttributeId",
                table: "CategoryAttributeHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttributeHistory",
                table: "CategoryAttributeHistory");

            migrationBuilder.RenameTable(
                name: "CategoryAttributeHistory",
                newName: "CategoryAttributeHistories");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttributeHistory_CategoryAttributeId",
                table: "CategoryAttributeHistories",
                newName: "IX_CategoryAttributeHistories_CategoryAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttributeHistory_AttributeId",
                table: "CategoryAttributeHistories",
                newName: "IX_CategoryAttributeHistories_AttributeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 215, DateTimeKind.Utc).AddTicks(4717),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 301, DateTimeKind.Utc).AddTicks(7997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(9332),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(1838));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(57),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(2990));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1298),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(4236));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(713),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(3739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4299),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(6885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3645),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3143),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(5890));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1962),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(4830));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(2546),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(5308));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(8487),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(772));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4813),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(7395));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttributeHistories",
                table: "CategoryAttributeHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributeHistories_Attributes_AttributeId",
                table: "CategoryAttributeHistories",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributeHistories_CategoryAttributes_CategoryAttributeId",
                table: "CategoryAttributeHistories",
                column: "CategoryAttributeId",
                principalTable: "CategoryAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributeHistories_Attributes_AttributeId",
                table: "CategoryAttributeHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_CategoryAttributeHistories_CategoryAttributes_CategoryAttributeId",
                table: "CategoryAttributeHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CategoryAttributeHistories",
                table: "CategoryAttributeHistories");

            migrationBuilder.RenameTable(
                name: "CategoryAttributeHistories",
                newName: "CategoryAttributeHistory");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttributeHistories_CategoryAttributeId",
                table: "CategoryAttributeHistory",
                newName: "IX_CategoryAttributeHistory_CategoryAttributeId");

            migrationBuilder.RenameIndex(
                name: "IX_CategoryAttributeHistories_AttributeId",
                table: "CategoryAttributeHistory",
                newName: "IX_CategoryAttributeHistory_AttributeId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 301, DateTimeKind.Utc).AddTicks(7997),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 215, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(1838),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(9332));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(2990),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(57));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(4236),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1298));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(3739),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(6885),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4299));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(6413),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3645));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(5890),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(3143));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(4830),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(1962));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(5308),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(2546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(772),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 216, DateTimeKind.Utc).AddTicks(8487));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistory",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 5, 31, 17, 55, 20, 303, DateTimeKind.Utc).AddTicks(7395),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 5, 31, 18, 4, 51, 217, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.AddPrimaryKey(
                name: "PK_CategoryAttributeHistory",
                table: "CategoryAttributeHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributeHistory_Attributes_AttributeId",
                table: "CategoryAttributeHistory",
                column: "AttributeId",
                principalTable: "Attributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CategoryAttributeHistory_CategoryAttributes_CategoryAttributeId",
                table: "CategoryAttributeHistory",
                column: "CategoryAttributeId",
                principalTable: "CategoryAttributes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
