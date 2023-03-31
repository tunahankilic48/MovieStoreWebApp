using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Models.DataTransferObjects.MovieDTOS;
using MovieStore.Application.Models.ViewModels.CategoryViewModels;
using MovieStore.Application.Models.ViewModels.DirectorViewModels;
using MovieStore.Application.Models.ViewModels.LanguageViewModels;
using MovieStore.Application.Models.ViewModels.MovieViewModels;
using MovieStore.Application.Models.ViewModels.StarringViewModels;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using MovieStore.Domain.Repositories;
using Image = SixLabors.ImageSharp.Image;

namespace MovieStore.Application.Services.MovieServices
{
    internal class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IDirectorRepository _directorRepository;
        private readonly IStarringRepository _starringRepository;
        private readonly ILanguageRepository _languageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, IMapper mapper, IDirectorRepository directorRepository, IStarringRepository starringRepository, ILanguageRepository languageRepository, ICategoryRepository categoryRepository)
        {
            _movieRepository = movieRepository;
            _mapper = mapper;
            _directorRepository = directorRepository;
            _starringRepository = starringRepository;
            _languageRepository = languageRepository;
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Create(CreateMovieDTO model)
        {
            Movie newMovie = _mapper.Map<Movie>(model);

            if (model.Image != null)
            {
                using var image = Image.Load(model.Image.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");

                newMovie.ImagePath = $"/images/{guid}.jpg";
            }
            else
                newMovie.ImagePath = $"/images/defaultPost.jpg";

            return await _movieRepository.Add(newMovie);
        }

        public async Task<CreateMovieDTO> CreateMovie()
        {
            CreateMovieDTO createMovieDTO = new CreateMovieDTO()
            {
                Directors = await _directorRepository.GetFilteredList(
                    select: x => new DirectorVM()
                    {
                        Id = x.Id,
                        FullName = x.FullName

                    },
                    where: x => x.Statu != Status.Deleted && x.Statu != Status.Passive,
                    orderby: x => x.OrderBy(x => x.FullName)
                    ),

                Starrings = await _starringRepository.GetFilteredList(
                    select: x => new StarringVM()
                    {
                        Id = x.Id,
                        FullName = x.FullName

                    },
                    where: x => x.Statu != Status.Deleted && x.Statu != Status.Passive,
                    orderby: x => x.OrderBy(x => x.FullName)
                    ),

                Categories = await _categoryRepository.GetFilteredList(
                    select: x => new CategoryVM()
                    {
                        Id = x.Id,
                        Name = x.Name

                    },
                    where: x => x.Statu != Status.Deleted && x.Statu != Status.Passive,
                    orderby: x => x.OrderBy(x => x.Name)
                    ),

                Languages = await _languageRepository.GetFilteredList(
                    select: x => new LanguageVM()
                    {
                        Id = x.Id,
                        Name = x.Name

                    },
                    where: x => x.Statu != Status.Deleted && x.Statu != Status.Passive,
                    orderby: x => x.OrderBy(x => x.Name)
                    ),

            };

            return createMovieDTO;

        }

        public async Task<bool> Delete(int id)
        {
            Movie movie = await _movieRepository.GetDefault(x => x.Id == id);
            movie.Statu = Status.Deleted;
            return await _movieRepository.Delete(movie);
        }

        public async Task<UpdateMovieDTO> GetById(int id)
        {
            Movie movie = await _movieRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateMovieDTO>(movie);
        }

        public async Task<MovieDetailsVM> GetMovieDetails(int id)
        {
            MovieDetailsVM movie = await _movieRepository.GetFilteredFirstOrDefault(
               select: x => new MovieDetailsVM
               {
                   Id = x.Id,
                   Name = x.Name,
                   Description = x.Description,
                   ImagePath = x.ImagePath,
                   DirectorName = x.Director.FullName,
                   CategoryName = x.Category.Name,
                   Price = x.Price,
                   ReleaseDate = x.ReleaseDate,
                   RunningTimeMin = x.RunningTimeMin,
                   LanguageName = x.Language.Name,
                   Stock = x.Stock,
                   IsActive = x.IsActive
               },
               where: x => x.Id == id,
               include: x => x.Include(x => x.Category).Include(x => x.Director).Include(x => x.Language)
               );

            return movie;
        }

        public async Task<List<MovieVM>> GetMovies()
        {
            List<MovieVM> movies = await _movieRepository.GetFilteredList(
                select: x => new MovieVM
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description.Length > 30 ? x.Description.Substring(0, 30) + "..." : x.Description,
                    ImagePath = x.ImagePath,
                    DirectorName = x.Director.FullName,
                    CategoryName = x.Category.Name,
                    Price = x.Price,
                },
                where: x => x.Statu != Status.Deleted && x.Statu != Status.Passive,
                orderby: x => x.OrderBy(x => x.Name),
                include: x => x.Include(x => x.Category).Include(x => x.Director)
                );

            return movies;
        }

        public async Task<bool> Update(UpdateMovieDTO model)
        {
            Movie newMovie = _mapper.Map<Movie>(model);

            if (model.Image != null)
            {
                using var image = Image.Load(model.Image.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                image.Save($"wwwroot/images/{guid}.jpg");

                newMovie.ImagePath = $"/images/{guid}.jpg";
            }
            else
                newMovie.ImagePath = model.ImagePath;

            return await _movieRepository.Update(newMovie);
        }
        // ToDo: Update ksımında doldurma alanları ayarlanacak
        public Task<UpdateMovieDTO> UpdateMovie()
        {
            throw new NotImplementedException();
        }
    }
}
