using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace zadatak_dev.Data.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users_Test",
                columns: table => new
                {
                    Id_User = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users_Test", x => x.Id_User);
                });

            migrationBuilder.CreateTable(
                name: "Preferences_Test",
                columns: table => new
                {
                    Id_Preference = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Zanr_Knjige = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naziv_Knjige = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autor_Knjige = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    User_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Preferences_Test", x => x.Id_Preference);
                    table.ForeignKey(
                        name: "FK_Preferences_Test_Users_Test_User_Id",
                        column: x => x.User_Id,
                        principalTable: "Users_Test",
                        principalColumn: "Id_User",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Preferences_Test_User_Id",
                table: "Preferences_Test",
                column: "User_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Preferences_Test");

            migrationBuilder.DropTable(
                name: "Users_Test");
        }
    }
}
