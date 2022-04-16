using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Color_Library.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Red = table.Column<byte>(type: "INTEGER", nullable: false),
                    Green = table.Column<byte>(type: "INTEGER", nullable: false),
                    Blue = table.Column<byte>(type: "INTEGER", nullable: false),
                    Transparency = table.Column<byte>(type: "INTEGER", nullable: false),
                    ColorName = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
