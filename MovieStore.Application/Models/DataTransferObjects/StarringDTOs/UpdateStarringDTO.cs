using MovieStore.Domain.Enums;

namespace MovieStore.Application.Models.DataTransferObjects.StarringDTOs
{
    public class UpdateStarringDTO
    {
        // ToDo: FluentValidaton
        public int? Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Status Statu { get; set; }
    }
}
