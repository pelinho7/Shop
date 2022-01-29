using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ShippingAddressesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "ShippingAddresses");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 199, DateTimeKind.Utc).AddTicks(5350),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 990, DateTimeKind.Utc).AddTicks(4173));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9789),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 991, DateTimeKind.Utc).AddTicks(8505));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 201, DateTimeKind.Utc).AddTicks(322),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 991, DateTimeKind.Utc).AddTicks(9065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9069),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 991, DateTimeKind.Utc).AddTicks(7674));

            migrationBuilder.CreateTable(
                name: "ShippingAddress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    BuildingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    FlatNumber = table.Column<string>(type: "TEXT", nullable: true),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 201, DateTimeKind.Utc).AddTicks(941))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddress", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddress_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddress_AppUserId",
                table: "ShippingAddress",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropTable(
            //     name: "ShippingAddress");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 990, DateTimeKind.Utc).AddTicks(4173),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 199, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 991, DateTimeKind.Utc).AddTicks(8505),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 991, DateTimeKind.Utc).AddTicks(9065),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 201, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 991, DateTimeKind.Utc).AddTicks(7674),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.CreateTable(
                name: "ShippingAddresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AppUserId = table.Column<int>(type: "INTEGER", nullable: false),
                    BuildingNumber = table.Column<string>(type: "TEXT", nullable: false),
                    City = table.Column<string>(type: "TEXT", nullable: false),
                    Country = table.Column<string>(type: "TEXT", nullable: false),
                    Deleted = table.Column<bool>(type: "INTEGER", nullable: false),
                    FirstName = table.Column<string>(type: "TEXT", nullable: false),
                    FlatNumber = table.Column<string>(type: "TEXT", nullable: true),
                    LastName = table.Column<string>(type: "TEXT", nullable: false),
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 1, 27, 19, 31, 14, 991, DateTimeKind.Utc).AddTicks(9645)),
                    Phone = table.Column<string>(type: "TEXT", nullable: false),
                    Street = table.Column<string>(type: "TEXT", nullable: true),
                    ZipCode = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddresses_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddresses_AppUserId",
                table: "ShippingAddresses",
                column: "AppUserId");
        }
    }
}
