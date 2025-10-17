using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BeetleMovies.Migrations
{
    /// <inheritdoc />
    public partial class SeedMoviesAndDirectors : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", maxLength: 150, nullable: false),
                    Year = table.Column<int>(type: "INTEGER", nullable: false),
                    Rating = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DirectorMovie",
                columns: table => new
                {
                    DirectorsId = table.Column<int>(type: "INTEGER", nullable: false),
                    MoviesId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovie", x => new { x.DirectorsId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Directors_DirectorsId",
                        column: x => x.DirectorsId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovie_Movies_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Steven Spielberg" },
                    { 2, "Christopher Nolan" },
                    { 3, "Quentin Tarantino" },
                    { 4, "Martin Scorsese" },
                    { 5, "James Cameron" },
                    { 6, "Ridley Scott" },
                    { 7, "Peter Jackson" },
                    { 8, "Francis Ford Coppola" },
                    { 9, "David Fincher" },
                    { 10, "Clint Eastwood" },
                    { 11, "George Lucas" },
                    { 12, "Tim Burton" },
                    { 13, "Woody Allen" },
                    { 14, "Sofia Coppola" },
                    { 15, "Wes Anderson" },
                    { 16, "Guillermo del Toro" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Rating", "Title", "Year" },
                values: new object[,]
                {
                    { 1, 8.0999999999999996, "Jurassic Park", 1993 },
                    { 2, 8.8000000000000007, "Inception", 2010 },
                    { 3, 8.9000000000000004, "Pulp Fiction", 1994 },
                    { 4, 9.0, "The Dark Knight", 2008 },
                    { 5, 9.1999999999999993, "The Godfather", 1972 },
                    { 6, 7.7999999999999998, "Titanic", 1997 },
                    { 7, 8.5, "Gladiator", 2000 },
                    { 8, 8.9000000000000004, "The Lord of the Rings: The Return of the King", 2003 },
                    { 9, 9.3000000000000007, "The Shawshank Redemption", 1994 },
                    { 10, 8.8000000000000007, "Fight Club", 1999 },
                    { 11, 8.8000000000000007, "Forrest Gump", 1994 },
                    { 12, 8.5999999999999996, "Star Wars: Episode IV - A New Hope", 1977 },
                    { 13, 7.9000000000000004, "Edward Scissorhands", 1990 }
                });

            migrationBuilder.InsertData(
                table: "DirectorMovie",
                columns: new[] { "DirectorsId", "MoviesId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 2 },
                    { 2, 4 },
                    { 3, 3 },
                    { 4, 9 },
                    { 5, 6 },
                    { 6, 7 },
                    { 7, 8 },
                    { 8, 5 },
                    { 9, 10 },
                    { 10, 11 },
                    { 11, 12 },
                    { 12, 13 },
                    { 13, 13 },
                    { 14, 10 },
                    { 15, 9 },
                    { 16, 8 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovie_MoviesId",
                table: "DirectorMovie",
                column: "MoviesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorMovie");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Movies");
        }
    }
}
