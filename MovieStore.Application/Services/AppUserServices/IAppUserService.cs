﻿using Microsoft.AspNetCore.Identity;
using MovieStore.Application.Models.DataTransferObjects.AppUserDTOs;

namespace MovieStore.Application.Services.AppUserServices
{
    public interface IAppUserService
    {
        Task<IdentityResult> Registor(RegistorDTO model);
        Task<SignInResult> Login(LoginDTO model);
        Task Logout();
        Task UpdateUser(UpdateProfileDTO model);
        Task<UpdateProfileDTO> GetByUserName(string userName);
        Task<IList<string>> GetUserRole(string userName);
        Task<bool> IsAdmin(string userName);
    }
}
