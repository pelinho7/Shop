using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class DefaultValuesMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 753, DateTimeKind.Utc).AddTicks(9131),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 755, DateTimeKind.Utc).AddTicks(2742),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 755, DateTimeKind.Utc).AddTicks(3266),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 755, DateTimeKind.Utc).AddTicks(2049),
                oldClrType: typeof(DateTime),
                oldType: "TEXT");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserHistories",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 753, DateTimeKind.Utc).AddTicks(9131));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreements",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 755, DateTimeKind.Utc).AddTicks(2742));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "UserAgreementHistories",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 755, DateTimeKind.Utc).AddTicks(3266));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ModDate",
                table: "Agreements",
                type: "TEXT",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "TEXT",
                oldDefaultValue: new DateTime(2022, 1, 18, 19, 38, 57, 755, DateTimeKind.Utc).AddTicks(2049));
        }
    }
}
