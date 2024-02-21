using AutoMapper;
using movies_api.DTOs;
using movies_api.Models;
using movies_api.Repositories;

namespace movies_api.Services;

public class MovieService : IMovieService
{
    private readonly IMovieRepository _repository;
    private readonly IMapper _mapper;
    
    public MovieService(IMapper mapper, IMovieRepository repository) 
    {
        _mapper = mapper;
        _repository = repository;
    }

    public async Task AddMovieAsync(MovieDto dto)
    {
        var movie = _mapper.Map<Movie>(dto);

        if(movie != null)
            await _repository.AddAsync(movie);
        else
            throw new Exception("Error when adding User");
    }

    public async Task<IEnumerable<MovieDto>> GetAllMoviesAsync(int skip, int take)
    {
        var movies = await _repository.GetAllAsync(skip, take);
        
        var list = _mapper.Map<IEnumerable<MovieDto>>(movies);

        if(list != null)
            return list;
        else 
            throw new Exception("Error while mapping User List");
    }

    public async Task<MovieDto?> GetMovieByIdAsync(int id)
    {
        var movie = await _repository.GetByIdAsync(id);

        var dto = _mapper.Map<MovieDto>(movie);

        if(dto != null)
            return dto;
        else 
            throw new Exception("Error while mapping UserDto");
    }
}