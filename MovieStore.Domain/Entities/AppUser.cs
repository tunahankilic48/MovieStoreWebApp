using Microsoft.AspNetCore.Identity;
using MovieStore.Domain.Enums;

namespace MovieStore.Domain.Entities
{
    public class AppUser : IdentityUser, IBaseEntity
    {
        public string ImagePath { get; set; }
        public Status Statu { get; set; }
    }
}
