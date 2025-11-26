using AutoMapper;
namespace BeetleMovies;

public class BeetleMovieProfile : Profile
{
    public BeetleMovieProfile()
    {
        CreateMap<Movie, MovieDTO>().ReverseMap();
        CreateMap<Movie, MovieForCreatingDTO>().ReverseMap();
        CreateMap<Director, DirectorDTO>().ForMember(d => d.MovieId, o => o.MapFrom(d => d.Movies.First().Id));
    }
}