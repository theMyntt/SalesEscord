using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication;
using SalesEscord.Context;
using SalesEscord.Exceptions;
using SalesEscord.Interfaces;
using SalesEscord.Models.Persistance;

namespace SalesEscord.Services
{
    public class UserService : IUserService
    {
        private readonly DatabaseContext _context;
        private readonly DbSet<UserModel> _users;
        private readonly IBtoaHandler _btoaHandler;

        public UserService(DatabaseContext context, IBtoaHandler btoaHandler)
        {
            _context = context;
            _users = _context.Set<UserModel>();
            _btoaHandler = btoaHandler;
        }

        public async Task<ClaimsPrincipal> Login(string email, string password)
        {
            var encryptPassword = _btoaHandler.Encrypt(password);
            
            password = string.Empty;

            var user = await _users.FirstOrDefaultAsync(u => 
                u.Email.ToLower() == email.ToLower().Trim()
                && u.Password == encryptPassword.Trim());

            if (user == null) {
                throw new UnauthorizedException("User Not Found");
            }

            user.Password = string.Empty;

            if (user.IsBlocked)
            {
                throw new ForbiddenException("User Is Blocked");
            }

            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, user.Name),
                new(ClaimTypes.Role, user.Role)
            };

            var identityClaims = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identityClaims);

            return principal;
        }
    }
}
