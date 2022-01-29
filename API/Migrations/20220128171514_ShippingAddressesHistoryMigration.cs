using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class ShippingAddressesHistoryMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddress_AspNetUsers_AppUserId",
                table: "ShippingAddress");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddress",
                table: "ShippingAddress");

            migrationBuilder.RenameTable(
                name: "ShippingAddress",
                newName: "ShippingAddresses");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingAddress_AppUserId",
                table: "ShippingAddresses",
                newName: "IX_ShippingAddresses_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 330, DateTimeKind.Utc).AddTicks(3136),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 199, DateTimeKind.Utc).AddTicks(5350));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7022),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7546),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 201, DateTimeKind.Utc).AddTicks(322));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(6321),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9069));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddresses",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(8160),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 201, DateTimeKind.Utc).AddTicks(941));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShippingAddressHistories",
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
                    ModDate = table.Column<DateTime>(type: "TEXT", nullable: false, defaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(8655)),
                    ShippingAddressId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShippingAddressHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShippingAddressHistories_AspNetUsers_AppUserId",
                        column: x => x.AppUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShippingAddressHistories_ShippingAddresses_ShippingAddressId",
                        column: x => x.ShippingAddressId,
                        principalTable: "ShippingAddresses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddressHistories_AppUserId",
                table: "ShippingAddressHistories",
                column: "AppUserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShippingAddressHistories_ShippingAddressId",
                table: "ShippingAddressHistories",
                column: "ShippingAddressId");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_AppUserId",
                table: "ShippingAddresses",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ShippingAddresses_AspNetUsers_AppUserId",
                table: "ShippingAddresses");

            migrationBuilder.DropTable(
                name: "ShippingAddressHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShippingAddresses",
                table: "ShippingAddresses");

            migrationBuilder.RenameTable(
                name: "ShippingAddresses",
                newName: "ShippingAddress");

            migrationBuilder.RenameIndex(
                name: "IX_ShippingAddresses_AppUserId",
                table: "ShippingAddress",
                newName: "IX_ShippingAddress_AppUserId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 199, DateTimeKind.Utc).AddTicks(5350),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 330, DateTimeKind.Utc).AddTicks(3136));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9789),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7022));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 201, DateTimeKind.Utc).AddTicks(322),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(7546));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 200, DateTimeKind.Utc).AddTicks(9069),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(6321));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "ShippingAddress",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 28, 17, 3, 14, 201, DateTimeKind.Utc).AddTicks(941),
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 28, 17, 15, 14, 331, DateTimeKind.Utc).AddTicks(8160));

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShippingAddress",
                table: "ShippingAddress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ShippingAddress_AspNetUsers_AppUserId",
                table: "ShippingAddress",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
