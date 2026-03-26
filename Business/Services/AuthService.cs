using Core.Abstracts.IServices;
using Core.Concretes.DTOs;
using Core.Concretes.Entities;
using Microsoft.AspNetCore.Identity;
using Utils.Responses;

namespace Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<Customer> userManager;
        private readonly SignInManager<Customer> signInManager;


        public AuthService(UserManager<Customer> userManager, SignInManager<Customer> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public async Task<IResult> LoginAsync(LoginDto model)
        {
            if (string.IsNullOrEmpty(model.UserName) || string.IsNullOrEmpty(model.Password))
            {
                return Result.Failure("Kullanıcı adı ve şifre boş olamaz!", 400);
            }

            var result = await signInManager.PasswordSignInAsync(
                model.UserName,
                model.Password,
                model.RememberMe,
                false);

            if (result.Succeeded)
            {
                return Result.Success();
            }
            else if (result.IsLockedOut)
            {
                return Result.Failure(
                    "Hesabınız güvenlik nedeniyle kilitlenmiştir. Lütfen daha sonra tekrar deneyin.",
                    403);
            }
            else if (result.IsNotAllowed)
            {
                return Result.Failure(
                    "Kullanıcı girişine izin verilmemiştir. Lütfen e-posta doğrulamasını kontrol edin.",
                    403);
            }
            else if (result.RequiresTwoFactor)
            {
                return Result.Failure(
                    "İki faktörlü kimlik doğrulama gereklidir.",
                    403);
            }
            else
            {
                return Result.Failure("Kullanıcı adı veya şifre hatalı!", 401);
            }
        }

        public async Task LogoutAsync()
        {
            await signInManager.SignOutAsync();
        }

        public Task<IResult> RegisterAsync(RegisterDto model)
        {
            throw new NotImplementedException();
        }
    }
}
