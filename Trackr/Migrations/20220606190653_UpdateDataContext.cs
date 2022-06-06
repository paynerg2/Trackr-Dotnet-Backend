using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Trackr.Migrations
{
    public partial class UpdateDataContext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contact_Users_UserId",
                table: "Contact");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Applications_ApplicationId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Contact_ContactId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Interview_Users_UserId",
                table: "Interview");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interview",
                table: "Interview");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contact",
                table: "Contact");

            migrationBuilder.RenameTable(
                name: "Interview",
                newName: "Interviews");

            migrationBuilder.RenameTable(
                name: "Contact",
                newName: "Contacts");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_UserId",
                table: "Interviews",
                newName: "IX_Interviews_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_ContactId",
                table: "Interviews",
                newName: "IX_Interviews_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Interview_ApplicationId",
                table: "Interviews",
                newName: "IX_Interviews_ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Contact_UserId",
                table: "Contacts",
                newName: "IX_Contacts_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "SettingsId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Contacts_ContactId",
                table: "Interviews",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interviews_Users_UserId",
                table: "Interviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users",
                column: "SettingsId",
                principalTable: "Settings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Applications_ApplicationId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Contacts_ContactId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Interviews_Users_UserId",
                table: "Interviews");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Interviews",
                table: "Interviews");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Contacts",
                table: "Contacts");

            migrationBuilder.RenameTable(
                name: "Interviews",
                newName: "Interview");

            migrationBuilder.RenameTable(
                name: "Contacts",
                newName: "Contact");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_UserId",
                table: "Interview",
                newName: "IX_Interview_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_ContactId",
                table: "Interview",
                newName: "IX_Interview_ContactId");

            migrationBuilder.RenameIndex(
                name: "IX_Interviews_ApplicationId",
                table: "Interview",
                newName: "IX_Interview_ApplicationId");

            migrationBuilder.RenameIndex(
                name: "IX_Contacts_UserId",
                table: "Contact",
                newName: "IX_Contact_UserId");

            migrationBuilder.AlterColumn<string>(
                name: "SettingsId",
                table: "Users",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Interview",
                table: "Interview",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Contact",
                table: "Contact",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Contact_Users_UserId",
                table: "Contact",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Applications_ApplicationId",
                table: "Interview",
                column: "ApplicationId",
                principalTable: "Applications",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Contact_ContactId",
                table: "Interview",
                column: "ContactId",
                principalTable: "Contact",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Interview_Users_UserId",
                table: "Interview",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Settings_SettingsId",
                table: "Users",
                column: "SettingsId",
                principalTable: "Settings",
                principalColumn: "Id");
        }
    }
}
