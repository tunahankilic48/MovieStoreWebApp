using AutoMapper;
using Microsoft.AspNetCore.Identity;
using MovieStore.Application.Models.DataTransferObjects.AppUserDTOs;
using MovieStore.Domain.Entities;
using MovieStore.Domain.Repositories;

namespace MovieStore.Application.Services.AppUserServices
{
    internal class AppUserService : IAppUserService
    {
        private readonly IAppUserRepository _repository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AppUserService(IAppUserRepository repository, SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, IMapper mapper)
        {
            _repository = repository;
            _signInManager = signInManager;
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<UpdateProfileDTO> GetByUserName(string userName)
        {
            UpdateProfileDTO result = await _repository.GetFilteredFirstOrDefault(
                select: x => new UpdateProfileDTO()
                {
                    Id = x.Id,
                    UserName = x.UserName,
                    Password = x.PasswordHash,
                    Email = x.Email,
                    ImagePath = x.ImagePath,
                },
                where: x => x.UserName == userName
                );

            return result;
        }

        public async Task<SignInResult> Login(LoginDTO model)
        {
            SignInResult result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
            return result;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> Registor(RegistorDTO model)
        {
            AppUser user = _mapper.Map<AppUser>(model);

            user.ImagePath = "/images/noImage.png";

            IdentityResult result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
            }

            return result;
        }

        public async Task UpdateUser(UpdateProfileDTO model)
        {
            AppUser user = await _repository.GetDefault(x => x.Id == model.Id);

            if (model.UploadPath != null)
            {
                using var image = Image.Load(model.UploadPath.OpenReadStream());
                image.Mutate(x => x.Resize(600, 560));
                Guid guid = Guid.NewGuid();
                var extension = Path.GetExtension(model.UploadPath.FileName).ToLower();
                image.Save($"wwwroot/images/{guid}{extension}");

                user.ImagePath = $"/images/{guid}{extension}";
                await _userManager.UpdateAsync(user);
            }

            if (model.Password != null)
            {
                if (model.Password == model.ConfirmPassword)
                {
                    user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, model.Password);
                    await _userManager.UpdateAsync(user);
                }
            }

            if (model.Email != null)
            {
                AppUser isEmailExist = await _repository.GetDefault(x=>x.Email == model.Email);

                if (isEmailExist == null)
                {
                    await _userManager.SetEmailAsync(user, model.Email);
                }
            }

            if(model.UserName != null) 
            {
                var isUserNameExist = await _userManager.FindByNameAsync(model.UserName);
                if (isUserNameExist == null)
                {
                    await _userManager.SetUserNameAsync(user, model.UserName);
                }
            }

        }

        public async Task<IList<string>> GetUserRole(string userName)
        {
            AppUser user = await _userManager.FindByNameAsync(userName);
            var result = await _userManager.GetRolesAsync(user);
            return result;
        }

        public async Task<bool> IsAdmin(string userName)
        {
            var roles = await GetUserRole(userName);

            foreach (var role in roles)
            {
                if(role == "Admin")
                    return true;
            }
            return false;
        }

    }
}
