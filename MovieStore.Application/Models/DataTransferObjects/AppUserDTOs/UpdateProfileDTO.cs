using Microsoft.AspNetCore.Http;
using MovieStore.Domain.Enums;

namespace MovieStore.Application.Models.DataTransferObjects.AppUserDTOs
{
    public class UpdateProfileDTO
    {
        //ToDo: DataAnnotations
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string? Email { get; set; }
        public string? ImagePath{ get; set; }
        public IFormFile? UploadPath{ get; set; }
        public Status Statu { get; set; }
    }
}
