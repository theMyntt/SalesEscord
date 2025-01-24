using System.Security.Claims;
using SalesEscord.Models.Persistance;

namespace SalesEscord.Interfaces
{
    public interface IUserService
    {
        Task<ClaimsPrincipal> Login(string email, string password);
    }
}
