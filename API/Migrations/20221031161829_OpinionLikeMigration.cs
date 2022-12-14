using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class OpinionLikeMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(325),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(8888));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 920, DateTimeKind.Utc).AddTicks(8994),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 23, DateTimeKind.Utc).AddTicks(6448));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3963),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(2646));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(4826),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(3263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6183),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(4625));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(5593),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(3927));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2047),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(628));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3115),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(1586));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4075),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(2318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5740),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(3825));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5422),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(3498));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2850),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(1309));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3577),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(1834));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4724),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(2956));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(891),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(9463));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6545),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(4637));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6220),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(4379));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(1494),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(42));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9094),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(7629));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8570),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(7110));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9601),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(8273));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8010),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(6490));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6868),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(5342));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(7443),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(5921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3166),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(1911));

            migrationBuilder.CreateTable(
                name: "OpinionLikes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    OpinionId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpinionLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpinionLikes_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OpinionLikes_Opinions_OpinionId",
                        column: x => x.OpinionId,
                        principalTable: "Opinions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OpinionLikes_AppUserId_OpinionId",
                table: "OpinionLikes",
                columns: new[] { "AppUserId", "OpinionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpinionLikes_OpinionId",
                table: "OpinionLikes",
                column: "OpinionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OpinionLikes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Warehouses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(8888),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(325));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 23, DateTimeKind.Utc).AddTicks(6448),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 920, DateTimeKind.Utc).AddTicks(8994));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(2646),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3963));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(3263),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(4826));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddressHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(4625),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6183));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(3927),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(5593));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(628),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2047));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductTextAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(1586),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3115));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductTextAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(2318),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4075));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(3825),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5740));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Products",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(3498),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(5422));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(1309),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(2850));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "ProductNumberAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(1834),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(3577));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductNumberAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(2956),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(4724));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ProductAmounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(9463),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(891));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(4637),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6545));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Opinions",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(4379),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(6220));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Discounts",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 26, DateTimeKind.Utc).AddTicks(42),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 923, DateTimeKind.Utc).AddTicks(1494));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(7629),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9094));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(7110),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8570));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "CategoryAttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(8273),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(9601));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Categories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(6490),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(8010));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Attributes",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(5342),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(6868));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "AttributeHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(5921),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(7443));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 10, 20, 16, 24, 45, 25, DateTimeKind.Utc).AddTicks(1911),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 10, 31, 16, 18, 28, 922, DateTimeKind.Utc).AddTicks(3166));
        }
    }
}
