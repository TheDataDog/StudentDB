using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace StudentDB.Migrations.SystemUserDb
{
    /// <inheritdoc />
    public partial class LogInUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserRoleId",
                table: "SystemUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SystemUsers_UserRoleId",
                table: "SystemUsers",
                column: "UserRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_SystemUsers_UserRoles_UserRoleId",
                table: "SystemUsers",
                column: "UserRoleId",
                principalTable: "UserRoles",
                principalColumn: "UserRoleId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SystemUsers_UserRoles_UserRoleId",
                table: "SystemUsers");

            migrationBuilder.DropIndex(
                name: "IX_SystemUsers_UserRoleId",
                table: "SystemUsers");

            migrationBuilder.DropColumn(
                name: "UserRoleId",
                table: "SystemUsers");
        }
    }
}
