using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Models.DataTransferObjects.DirectorDTOs;
using MovieStore.Application.Models.ViewModels.DirectorViewModels;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using MovieStore.Domain.Repositories;

namespace MovieStore.Application.Services.DirectorServices
{
    internal class DirectorService : IDirectorService
    {
        // ToDo: yönetiline filmler dropboxa dolacak
        private readonly IDirectorRepository _directorRepository;
        private readonly IMapper _mapper;

        public DirectorService(IDirectorRepository directorRepository, IMapper mapper)
        {
            _directorRepository = directorRepository;
            _mapper = mapper;
        }

        public async Task<bool> Create(CreateDirectorDTO model)
        {
            Director newDirector = _mapper.Map<Director>(model);
            return await _directorRepository.Add(newDirector);
        }

        public async Task<bool> Delete(int id)
        {
            Director director = await _directorRepository.GetDefault(x => x.Id == id);
            director.Statu = Status.Deleted;
            return await _directorRepository.Delete(director);
        }

        public async Task<UpdateDirectorDTO> GetById(int id)
        {
            Director director = await _directorRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateDirectorDTO>(director);

        }

        public async Task<DirectorDetailsVM> GetDirectorDetails(int id)
        {
            DirectorDetailsVM director = await _directorRepository.GetFilteredFirstOrDefault(
                            select: x => new DirectorDetailsVM
                            {
                                Id = x.Id,
                                FullName = x.FirstName + " " + x.LastName,
                                BirthDate = x.BirthDate != null ? ((DateTime)(x.BirthDate)).ToShortDateString() : null,
                                Statu = x.Statu,

                            },
                            where: x => x.Id == id,
                            include: x => x.Include(x => x.DirectedMovies)
                            );

            return director;
        }

        public async Task<List<DirectorVM>> GetDirectors()
        {
            List<DirectorVM> directors = await _directorRepository.GetFilteredList(
                select: x => new DirectorVM()
                {
                    Id = x.Id,
                    FullName = x.FirstName + " " + x.LastName,
                    BirthDate = x.BirthDate != null ? ((DateTime)(x.BirthDate)).ToShortDateString() : null,
                    Statu = x.Statu

                },
                where: x => x.Statu != Status.Deleted && x.Statu != Status.Passive,
                orderby: x => x.OrderBy(x => x.FirstName)
                );
            return directors;
        }

        public async Task<bool> Update(UpdateDirectorDTO model)
        {
            Director updateDirector = _mapper.Map<Director>(model);
            return await _directorRepository.Update(updateDirector);
        }
    }
}
