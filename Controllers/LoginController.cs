using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesEscord.DTOs;
using SalesEscord.Exceptions;
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

        [Authorize]
        public IActionResult Forbidden()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);

            try
            {
                var claims = await _userService.Login(dto.Email, dto.Password);

                await HttpContext.SignInAsync(claims);

                return LocalRedirect("/");
            } 
            catch (HttpException ex)
            {
                ModelState.AddModelError("Password", ex.Message);
                return View(dto);
            } 
        }
    }
}
