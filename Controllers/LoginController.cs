using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using SalesEscord.DTOs;
using SalesEscord.Interfaces;

namespace SalesEscord.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            var claims = await _userService.Login(dto.Email, dto.Password);

            await HttpContext.SignInAsync(claims);

            return LocalRedirect("/");
        }
    }
}
