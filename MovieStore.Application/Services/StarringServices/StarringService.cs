using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Application.Models.DataTransferObjects.StarringDTOs;
using MovieStore.Application.Models.ViewModels.StarringViewModels;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Enums;
using MovieStore.Domain.Repositories;

namespace MovieStore.Application.Services.StarringServices
{
    internal class StarringService : IStarringService
    {
        private readonly IStarringRepository _starringRepository;
        private readonly IMapper _mapper;

        public StarringService(IStarringRepository starringRepository, IMapper mapper)
        {
            _starringRepository = starringRepository;
            _mapper = mapper;
        }
        public async Task<bool> Create(CreateStarringDTO model)
        {
            Starring newStarring = _mapper.Map<Starring>(model);
            return await _starringRepository.Add(newStarring);
        }

        public async Task<bool> Delete(int id)
        {
            Starring starring = await _starringRepository.GetDefault(x => x.Id == id);
            starring.Statu = Status.Deleted;
            return await _starringRepository.Delete(starring);
        }

        public async Task<UpdateStarringDTO> GetById(int id)
        {
            Starring starring = await _starringRepository.GetDefault(x => x.Id == id);
            return _mapper.Map<UpdateStarringDTO>(starring);
        }

        public async Task<StarringDetailsVM> GetStarringDetails(int id)
        {
            StarringDetailsVM starring = await _starringRepository.GetFilteredFirstOrDefault(
                select: x => new StarringDetailsVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    Statu = x.Statu,

                },
                where: x => x.Id == id,
                include: x => x.Include(x => x.PerformedMovies)
                );

            return starring;
        }

        public async Task<List<StarringVM>> GetStarrings()
        {
            List<StarringVM> starring = await _starringRepository.GetFilteredList(
                select: x => new StarringVM
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    BirthDate = x.BirthDate,
                    Statu = x.Statu,

                },
                 where: x => x.Statu != Status.Deleted && x.Statu != Status.Passive,
                orderby: x => x.OrderBy(x => x.FirstName)
                );
            return starring;
        }

        public async Task<bool> Update(UpdateStarringDTO model)
        {
            Starring updateStarringr = _mapper.Map<Starring>(model);
            return await _starringRepository.Update(updateStarringr);
        }
    }
}
