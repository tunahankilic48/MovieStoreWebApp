using MovieStore.Domain.Enums;

namespace MovieStore.Application.Models.DataTransferObjects.DirectorDTOs
{
    internal class UpdateDirectorDTO
    {
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Status Statu { get; set; }


    }
}
