using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SalesEscord.DTOs;
using SalesEscord.Interfaces;
using SalesEscord.Models;

namespace SalesEscord.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ISalesService _service;

        public HomeController(ISalesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index([FromQuery] FindSalesDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var sales = await _service.FindAsync(dto.Page, dto.Limit);

            ViewBag.Page = dto.Page;
            ViewBag.Limit = dto.Limit;

            return View(sales);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
