using MovieStore.Domain.Enums;

namespace MovieStore.Application.Models.DataTransferObjects.StarringDTOs
{
    public class CreateStarringDTO
    {
        // ToDo: FluentValidaton
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? BirthDate { get; set; }
        public Status Statu => Status.Active;


    }
}
