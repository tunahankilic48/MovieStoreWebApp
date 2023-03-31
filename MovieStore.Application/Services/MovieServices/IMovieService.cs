using MovieStore.Application.Models.DataTransferObjects.MovieDTOS;
using MovieStore.Application.Models.ViewModels.MovieViewModels;

namespace MovieStore.Application.Services.MovieServices
{
    public interface IMovieService
    {
        Task<bool> Create(CreateMovieDTO model);
        Task<bool> Update(UpdateMovieDTO model);
        Task<bool> Delete(int id);
        Task<UpdateMovieDTO> GetById(int id);
        Task<List<MovieVM>> GetMovies();
        Task<MovieDetailsVM> GetMovieDetails(int id);
        Task<CreateMovieDTO> CreateMovie();
        Task<UpdateMovieDTO> UpdateMovie();
    }
}
