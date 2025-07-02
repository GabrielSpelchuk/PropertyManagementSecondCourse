using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PropertyManagement.BLL.Services.Interfaces
{
    public interface IJwtService
    {
        Task<bool> RegisterAsync(string username, string email, string password);
        Task<bool> ConfirmEmailAsync(string userId, string token);
        Task<(string accessToken, string refreshToken)> LoginAsync(string email, string password);
        Task<(string accessToken, string refreshToken)> RefreshTokenAsync(string expiredToken, string refreshToken);
        Task<bool> ForgotPasswordAsync(string email);
        Task<bool> ResetPasswordAsync(string email, string token, string newPassword);
        Task LogoutAsync();
    }
}
