using AutoMapper;
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
        private readonly IMapper mapper;


        public AuthService(UserManager<Customer> userManager, SignInManager<Customer> signInManager, IMapper mapper)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.mapper = mapper;
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

        // Kullanıcı oturumunu kapat
        public async Task LogoutAsync()
        {
            // Sistemde kayıtlı olan kullanıcının oturumunu sonlandır
            await signInManager.SignOutAsync();
        }

        // Yeni müşteri kaydı oluştur
        public async Task<IResult> RegisterAsync(RegisterDto model)
        {
            // RegisterDto modelini Customer entity'sine dönüştür
            var customer = mapper.Map<Customer>(model);

            // Dönüştürülen müşteriyi verilen şifre ile birlikte sisteme ekle
            var result = await userManager.CreateAsync(customer, model.Password);

            // Kayıt işlemi başarılı mı kontrol et
            if (result.Succeeded)
            {
                // Başarılı ise başarı sonucu döndür
                return Result.Success();
            }
            else
            {
                // Başarısız ise hata mesajlarını döndür
                return Result.Failure(result.Errors.Select(x => x.Description));
            }
        }
    }
}
