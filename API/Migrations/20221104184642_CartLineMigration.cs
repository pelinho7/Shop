using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class CartLineMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(2467),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(530));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 755, DateTimeKind.Utc).AddTicks(1792),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 537, DateTimeKind.Utc).AddTicks(9340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6389),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(4455));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6963),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8177),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6264));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(7568),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5627));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(4465),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2304));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5411),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3176));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6214),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3997));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7718),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5651));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7451),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5340));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5092),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2913));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5677),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3504));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6759),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(4765));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3184),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1053));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8470),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6597));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8170),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6262));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3829),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1663));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1233),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9271));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(707),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8689));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1807),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9796));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(34),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8851),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6979));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(9521),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(7563));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(5539),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(3653));

            migrationBuilder.CreateTable(
                name: "CartLines",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false),
                    CartId = table.Column<Guid>(type: "TEXT", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartLines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartLines_Carts_CartId",
                        column: x => x.CartId,
                        principalTable: "Carts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CartLines_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_CartId",
                table: "CartLines",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_CartLines_ProductId",
                table: "CartLines",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartLines");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(530),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(2467));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 537, DateTimeKind.Utc).AddTicks(9340),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 755, DateTimeKind.Utc).AddTicks(1792));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(4455),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6389));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5075),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(6963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6264),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8177));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(5627),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(7568));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2304),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(4465));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3176),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5411));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3997),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6214));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5651),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(5340),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(7451));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(2913),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5092));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(3504),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(5677));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(4765),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(6759));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1053),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6597),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8470));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(6262),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(8170));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 540, DateTimeKind.Utc).AddTicks(1663),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(3829));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9271),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1233));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8689),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(9796),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(1807));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(8092),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 757, DateTimeKind.Utc).AddTicks(34));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(6979),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(8851));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(7563),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(9521));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 11, 3, 19, 13, 22, 539, DateTimeKind.Utc).AddTicks(3653),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 11, 4, 18, 46, 41, 756, DateTimeKind.Utc).AddTicks(5539));
        }
    }
}
