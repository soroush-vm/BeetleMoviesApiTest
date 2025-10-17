using Microsoft.EntityFrameworkCore;
namespace BeetleMovies;
public class BeetleMoviesContext(DbContextOptions<BeetleMoviesContext> options) : DbContext(options)
{
    public DbSet<Movie> Movies { get; set; }

    public DbSet<Director> Directors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Director>().HasData(
            new Director { Id = 1, Name = "Steven Spielberg" },
            new Director { Id = 2, Name = "Christopher Nolan" },
            new Director { Id = 3, Name = "Quentin Tarantino" },
            new Director { Id = 4, Name = "Martin Scorsese" },
            new Director { Id = 5, Name = "James Cameron" },
            new Director { Id = 6, Name = "Ridley Scott" },
            new Director { Id = 7, Name = "Peter Jackson" },
            new Director { Id = 8, Name = "Francis Ford Coppola" },
            new Director { Id = 9, Name = "David Fincher" },
            new Director { Id = 10, Name = "Clint Eastwood" },
            new Director { Id = 11, Name = "George Lucas" },
            new Director { Id = 12, Name = "Tim Burton" },
            new Director { Id = 13, Name = "Woody Allen" },
            new Director { Id = 14, Name = "Sofia Coppola" },
            new Director { Id = 15, Name = "Wes Anderson" },
            new Director { Id = 16, Name = "Guillermo del Toro" }
        );
        modelBuilder.Entity<Movie>().HasData(
            new Movie { Id = 1, Title = "Jurassic Park", Year = 1993, Rating = 8.1 },
            new Movie { Id = 2, Title = "Inception", Year = 2010, Rating = 8.8 },
            new Movie { Id = 3, Title = "Pulp Fiction", Year = 1994, Rating = 8.9 },
            new Movie { Id = 4, Title = "The Dark Knight", Year = 2008, Rating = 9.0 },
            new Movie { Id = 5, Title = "The Godfather", Year = 1972, Rating = 9.2 },
            new Movie { Id = 6, Title = "Titanic", Year = 1997, Rating = 7.8 },
            new Movie { Id = 7, Title = "Gladiator", Year = 2000, Rating = 8.5 },
            new Movie { Id = 8, Title = "The Lord of the Rings: The Return of the King", Year = 2003, Rating = 8.9 },
            new Movie { Id = 9, Title = "The Shawshank Redemption", Year = 1994, Rating = 9.3 },
            new Movie { Id = 10, Title = "Fight Club", Year = 1999, Rating = 8.8 },
            new Movie { Id = 11, Title = "Forrest Gump", Year = 1994, Rating = 8.8 },
            new Movie { Id = 12, Title = "Star Wars: Episode IV - A New Hope", Year = 1977, Rating = 8.6 },
            new Movie { Id = 13, Title = "Edward Scissorhands", Year = 1990, Rating = 7.9 }
            // new Movie { Id = 14, Title = "Annie Hall", Year = 1977, Rating = 8.0 },
            // new Movie { Id = 15, Title = "Lost in Translation", Year = 2003, Rating = 7.7 },
            // new Movie { Id = 16, Title = "The Grand Budapest Hotel", Year = 2014, Rating = 8.1 },
            // new Movie { Id = 17, Title = "Pan's Labyrinth", Year = 2006, Rating = 8.2 }
        );
        modelBuilder.Entity<Movie>()
            .HasMany<Director>("Directors")
            .WithMany("Movies")
            .UsingEntity(j => j.HasData(
                new { MoviesId = 1, DirectorsId = 1 },
                new { MoviesId = 2, DirectorsId = 2 },
                new { MoviesId = 3, DirectorsId = 3 },
                new { MoviesId = 4, DirectorsId = 2 },
                new { MoviesId = 5, DirectorsId = 8 },
                new { MoviesId = 6, DirectorsId = 5 },
                new { MoviesId = 7, DirectorsId = 6 },
                new { MoviesId = 8, DirectorsId = 7 },
                new { MoviesId = 9, DirectorsId = 4 },
                new { MoviesId = 10, DirectorsId = 9 },
                new { MoviesId = 11, DirectorsId = 10 },
                new { MoviesId = 12, DirectorsId = 11 },
                new { MoviesId = 13, DirectorsId = 12 },
                new { MoviesId = 13, DirectorsId = 13 },
                new { MoviesId = 10, DirectorsId = 14 },
                new { MoviesId = 9, DirectorsId = 15 },
                new { MoviesId = 8, DirectorsId = 16 }
            ));
    }
}