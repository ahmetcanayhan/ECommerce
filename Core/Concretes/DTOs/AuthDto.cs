using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Concretes.DTOs
{
    public class LoginDto
    {
        [Required, Display (Name = "Kullanıcı Adınız", Prompt ="Kullanıcı Adınız")]
        public string UserName { get; set; } = null!;
        [Required, DataType (DataType.Password), Display(Name = "Parolanız")]
        public string Password { get; set; } = null!;
        [Display(Name = "Sizi Hatırlayalım")]
        public bool RememberMe { get; set; }
    }
    public class RegisterDto
    {
        [Required, Display (Name = "Adınız", Prompt ="Adınız")]
        public string FirstName { get; set; } = null!;
        [Required, Display (Name ="Soy Adınız", Prompt ="Soy Adınız")]
        public string LastName { get; set; } = null!;
        [Required, Display (Name ="Adres", Prompt ="Adres")]
        public string Address { get; set; } = null!;
        [Required, Display (Name ="İl", Prompt ="İl")]
        public string City { get; set; } = null!;
        [Required, Display(Name = "İlçe", Prompt = "İlçe")]
        public string District { get; set; } = null!;
        [Required, Display (Name ="Kullanıcı Adı", Prompt ="Kullanıcı Adı")]
        public string UserName { get; set; } = null!;
        [EmailAddress, Required, Display (Name ="E Posta", Prompt ="E Posta")]
        public string Email { get; set; } = null!;
        [Required, DataType(DataType.Password), Display(Name = "Parola", Prompt = "Parola")]
        public string Password { get; set; } = null!;
        [Required, DataType(DataType.Password), Display(Name = "Parolanızı Doğrulayın", Prompt = "Parolanızı Doğrulayın"), Compare("Password")]
        public string ConfirmPassword { get; set; } = null!;
    }

}
