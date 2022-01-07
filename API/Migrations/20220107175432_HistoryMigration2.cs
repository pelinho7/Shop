using Microsoft.EntityFrameworkCore.Migrations;

namespace API.Migrations
{
    public partial class HistoryMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AppUserHistory_AspNetUsers_AppUserId",
                table: "AppUserHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreement_Agreements_AgreementId",
                table: "UserAgreement");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreement_AspNetUsers_AppUserId",
                table: "UserAgreement");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreementHistory_Agreements_AgreementId",
                table: "UserAgreementHistory");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreementHistory_AspNetUsers_AppUserId",
                table: "UserAgreementHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAgreementHistory",
                table: "UserAgreementHistory");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAgreement",
                table: "UserAgreement");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AppUserHistory",
                table: "AppUserHistory");

            migrationBuilder.RenameTable(
                name: "UserAgreementHistory",
                newName: "UserAgreementHistories");

            migrationBuilder.RenameTable(
                name: "UserAgreement",
                newName: "UserAgreements");

            migrationBuilder.RenameTable(
                name: "AppUserHistory",
                newName: "UserHistories");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreementHistory_AppUserId",
                table: "UserAgreementHistories",
                newName: "IX_UserAgreementHistories_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreementHistory_AgreementId",
                table: "UserAgreementHistories",
                newName: "IX_UserAgreementHistories_AgreementId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreement_AppUserId",
                table: "UserAgreements",
                newName: "IX_UserAgreements_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreement_AgreementId",
                table: "UserAgreements",
                newName: "IX_UserAgreements_AgreementId");

            migrationBuilder.RenameIndex(
                name: "IX_AppUserHistory_AppUserId",
                table: "UserHistories",
                newName: "IX_UserHistories_AppUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAgreementHistories",
                table: "UserAgreementHistories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAgreements",
                table: "UserAgreements",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserHistories",
                table: "UserHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreementHistories_Agreements_AgreementId",
                table: "UserAgreementHistories",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreementHistories_AspNetUsers_AppUserId",
                table: "UserAgreementHistories",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreements_Agreements_AgreementId",
                table: "UserAgreements",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreements_AspNetUsers_AppUserId",
                table: "UserAgreements",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserHistories_AspNetUsers_AppUserId",
                table: "UserHistories",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreementHistories_Agreements_AgreementId",
                table: "UserAgreementHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreementHistories_AspNetUsers_AppUserId",
                table: "UserAgreementHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreements_Agreements_AgreementId",
                table: "UserAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserAgreements_AspNetUsers_AppUserId",
                table: "UserAgreements");

            migrationBuilder.DropForeignKey(
                name: "FK_UserHistories_AspNetUsers_AppUserId",
                table: "UserHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserHistories",
                table: "UserHistories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAgreements",
                table: "UserAgreements");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserAgreementHistories",
                table: "UserAgreementHistories");

            migrationBuilder.RenameTable(
                name: "UserHistories",
                newName: "AppUserHistory");

            migrationBuilder.RenameTable(
                name: "UserAgreements",
                newName: "UserAgreement");

            migrationBuilder.RenameTable(
                name: "UserAgreementHistories",
                newName: "UserAgreementHistory");

            migrationBuilder.RenameIndex(
                name: "IX_UserHistories_AppUserId",
                table: "AppUserHistory",
                newName: "IX_AppUserHistory_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreements_AppUserId",
                table: "UserAgreement",
                newName: "IX_UserAgreement_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreements_AgreementId",
                table: "UserAgreement",
                newName: "IX_UserAgreement_AgreementId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreementHistories_AppUserId",
                table: "UserAgreementHistory",
                newName: "IX_UserAgreementHistory_AppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserAgreementHistories_AgreementId",
                table: "UserAgreementHistory",
                newName: "IX_UserAgreementHistory_AgreementId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AppUserHistory",
                table: "AppUserHistory",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAgreement",
                table: "UserAgreement",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserAgreementHistory",
                table: "UserAgreementHistory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AppUserHistory_AspNetUsers_AppUserId",
                table: "AppUserHistory",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreement_Agreements_AgreementId",
                table: "UserAgreement",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreement_AspNetUsers_AppUserId",
                table: "UserAgreement",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreementHistory_Agreements_AgreementId",
                table: "UserAgreementHistory",
                column: "AgreementId",
                principalTable: "Agreements",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserAgreementHistory_AspNetUsers_AppUserId",
                table: "UserAgreementHistory",
                column: "AppUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
