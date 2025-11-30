using AutoMapper;
using BeetleMovies;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BeetleMoviesContext>(
    o => o.UseSqlite(builder.Configuration.GetConnectionString("BeetleMoviesStr"))
);

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/movies/{moviesId:int}/directors",async (BeetleMoviesContext context,IMapper mapper, int moviesId) =>
{
    return mapper.Map<IEnumerable<DirectorDTO>>((await context.Movies
        .Include(movie => movie.Directors)
        .FirstOrDefaultAsync(x => x.Id == moviesId))?.Directors);
});


app.MapGet("/movies", async Task<Results<NoContent, Ok<IEnumerable<MovieDTO>>>>
    (BeetleMoviesContext context,
    IMapper mapper,
    [FromQuery(Name = "movieName")] string? title) =>
{
    var movieEntity = await context.Movies.Where(x => title == null || x.Title.ToLower().Contains(title)).ToListAsync();
    if (movieEntity.Count <= 0 || movieEntity == null)
    {
        return TypedResults.NoContent();
    }
    else
    {
        return TypedResults.Ok(mapper.Map<IEnumerable<MovieDTO>>(movieEntity));
    }
});
app.MapGet("/movies/{id:int}", async (BeetleMoviesContext context,IMapper mapper, int id) =>
{
    return mapper.Map<MovieDTO>(await context.Movies.FirstOrDefaultAsync(x => x.Id == id));
}).WithName("GetMovies");

app.MapPost("/Movies", async(
    BeetleMoviesContext context,
    IMapper mapper,
    [FromBody] MovieForCreatingDTO movieForCreatingDto) =>
{
    var movie = mapper.Map<Movie>(movieForCreatingDto);
    context.Add(movie);
    await context.SaveChangesAsync();

    var movieToReturn = mapper.Map<MovieDTO>(movie);

    return TypedResults.CreatedAtRoute(movieToReturn, "GetMovies", new { id = movieToReturn.Id });
}
);

app.Run();
