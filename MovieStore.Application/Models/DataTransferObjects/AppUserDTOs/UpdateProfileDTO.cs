using MovieStore.Domain.Enums;

namespace MovieStore.Application.Models.DataTransferObjects.AppUserDTOs
{
    internal class UpdateProfileDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ConfirmedPassword { get; set; }
        public string Email { get; set; }
        public Status Statu { get; set; }
    }
}
