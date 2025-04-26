using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ExamenParcial.Models;
using ExamenParcial.Data;

namespace ExamenParcial.Controllers
{
    
    public class PlayerController : Controller
    {
        private readonly ILogger<PlayerController> _logger;
        private readonly ApplicationDbContext _context;

        public PlayerController(ILogger<PlayerController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Player jugador)
        {
        if (ModelState.IsValid)
        {
        _context.Add(jugador);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
        
        }
        return View(jugador);
}




















        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}