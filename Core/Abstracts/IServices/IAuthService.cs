using Core.Concretes.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utils.Responses;

namespace Core.Abstracts.IServices
{
    public interface IAuthService
    {
        Task<IResult> LoginAsync(LoginDto model);
        Task<IResult> RegisterAsync(RegisterDto model);
        Task LogoutAsync();
    }
}
