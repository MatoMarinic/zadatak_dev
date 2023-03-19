using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zadatak_dev.Data.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Preferences_Test_Users_Test_User_Id",
                table: "Preferences_Test");

            migrationBuilder.DropIndex(
                name: "IX_Preferences_Test_User_Id",
                table: "Preferences_Test");

            migrationBuilder.DropColumn(
                name: "User_Id",
                table: "Preferences_Test");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "User_Id",
                table: "Preferences_Test",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_Test_User_Id",
                table: "Preferences_Test",
                column: "User_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Preferences_Test_Users_Test_User_Id",
                table: "Preferences_Test",
                column: "User_Id",
                principalTable: "Users_Test",
                principalColumn: "Id_User",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
