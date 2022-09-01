using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ProductAmountMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(4276),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(7683));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 328, DateTimeKind.Utc).AddTicks(3289),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 209, DateTimeKind.Utc).AddTicks(8007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8265),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(1775));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8876),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(2464));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(50),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(3548));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(9457),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(3039));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2965),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(6413));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2291),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(5918));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(3617),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(7017));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1792),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(5375));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(712),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(4124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1278),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(4781));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(7556),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(1058));

            migrationBuilder.CreateTable(
                name: "ProductAmounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    WarehouseId = table.Column<int>(type: "INTEGER", nullable: false),
                    Amount = table.Column<decimal>(type: "TEXT", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(4778))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductAmounts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductAmounts_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductAmounts_Warehouses_WarehouseId",
                        column: x => x.WarehouseId,
                        principalTable: "Warehouses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductAmounts_ProductId",
                table: "ProductAmounts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductAmounts_WarehouseId",
                table: "ProductAmounts",
                column: "WarehouseId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductAmounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(7683),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(4276));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 209, DateTimeKind.Utc).AddTicks(8007),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 328, DateTimeKind.Utc).AddTicks(3289));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(1775),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8265));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(2464),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(8876));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(3548),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(50));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(3039),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(9457));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(6413),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2965));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(5918),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(2291));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(7017),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(3617));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(5375),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(4124),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(4781),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 330, DateTimeKind.Utc).AddTicks(1278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 8, 29, 18, 1, 47, 211, DateTimeKind.Utc).AddTicks(1058),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 8, 31, 9, 48, 55, 329, DateTimeKind.Utc).AddTicks(7556));
        }
    }
}
