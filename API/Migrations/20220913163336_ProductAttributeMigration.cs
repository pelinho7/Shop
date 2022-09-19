using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ProductAttributeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6851),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4016));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 336, DateTimeKind.Utc).AddTicks(6242),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 718, DateTimeKind.Utc).AddTicks(3712));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(735),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8129));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(1383),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8736));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2688),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9924));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2014),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7378),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7967),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(5109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5624),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2828));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5116),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6255),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(3363));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(4474),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1713));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3389),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3983),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1124));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(62),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(7294));

            migrationBuilder.CreateTable(
                name: "ProductNumberAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<decimal>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9634)),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9085))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNumberAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductNumberAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductNumberAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTextAttributes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Value = table.Column<string>(type: "TEXT", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(9452)),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(8565))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTextAttributes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTextAttributes_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTextAttributes_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductNumberAttributeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductNumberAttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 339, DateTimeKind.Utc).AddTicks(660))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductNumberAttributeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductNumberAttributeHistories_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductNumberAttributeHistories_ProductNumberAttributes_ProductNumberAttributeId",
                        column: x => x.ProductNumberAttributeId,
                        principalTable: "ProductNumberAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductNumberAttributeHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductTextAttributeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductTextAttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    AttributeId = table.Column<int>(type: "INTEGER", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 339, DateTimeKind.Utc).AddTicks(91))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductTextAttributeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductTextAttributeHistories_Attributes_AttributeId",
                        column: x => x.AttributeId,
                        principalTable: "Attributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTextAttributeHistories_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductTextAttributeHistories_ProductTextAttributes_ProductTextAttributeId",
                        column: x => x.ProductTextAttributeId,
                        principalTable: "ProductTextAttributes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumberAttributeHistories_AttributeId",
                table: "ProductNumberAttributeHistories",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumberAttributeHistories_ProductId",
                table: "ProductNumberAttributeHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumberAttributeHistories_ProductNumberAttributeId",
                table: "ProductNumberAttributeHistories",
                column: "ProductNumberAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumberAttributes_AttributeId",
                table: "ProductNumberAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductNumberAttributes_ProductId",
                table: "ProductNumberAttributes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTextAttributeHistories_AttributeId",
                table: "ProductTextAttributeHistories",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTextAttributeHistories_ProductId",
                table: "ProductTextAttributeHistories",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTextAttributeHistories_ProductTextAttributeId",
                table: "ProductTextAttributeHistories",
                column: "ProductTextAttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTextAttributes_AttributeId",
                table: "ProductTextAttributes",
                column: "AttributeId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductTextAttributes_ProductId",
                table: "ProductTextAttributes",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductNumberAttributeHistories");

            migrationBuilder.DropTable(
                name: "ProductTextAttributeHistories");

            migrationBuilder.DropTable(
                name: "ProductNumberAttributes");

            migrationBuilder.DropTable(
                name: "ProductTextAttributes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4016),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 718, DateTimeKind.Utc).AddTicks(3712),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 336, DateTimeKind.Utc).AddTicks(6242));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8129),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(735));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(8736),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(1383));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9924),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2688));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(9402),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(2014));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(4606),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7378));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(5109),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(7967));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2828),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5624));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(2326),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(5116));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(3363),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(6255));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1713),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(4474));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(505),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 720, DateTimeKind.Utc).AddTicks(1124),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(3983));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 9, 12, 8, 58, 1, 719, DateTimeKind.Utc).AddTicks(7294),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 9, 13, 16, 33, 36, 338, DateTimeKind.Utc).AddTicks(62));
        }
    }
}
