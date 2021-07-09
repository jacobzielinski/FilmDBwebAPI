using Microsoft.EntityFrameworkCore.Migrations;

namespace TT_Education_webAPI.API.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FilmModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearOfProduction = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserNotes = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FilmModels", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GenreModels",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GenreName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilmModelId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GenreModels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GenreModels_FilmModels_FilmModelId",
                        column: x => x.FilmModelId,
                        principalTable: "FilmModels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GenreModels_FilmModelId",
                table: "GenreModels",
                column: "FilmModelId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GenreModels");

            migrationBuilder.DropTable(
                name: "FilmModels");
        }
    }
}
