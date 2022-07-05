using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using TccAspNet.Models;
using TccAspNet.Data;

namespace TccAspNet.Controllers
{
    [Authorize(Roles = "Admin, Moderador")]
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly Contexto _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ILogger<AdminController> logger, Contexto contexto, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _context = contexto;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Settings(string data)
        {
            var user = await _userManager.GetUserAsync(User);
            user.Theme = data;
            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return View("Index");
        }
    }
}