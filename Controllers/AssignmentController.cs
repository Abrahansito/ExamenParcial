using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExamenParcial.Models;
using ExamenParcial.Data;

namespace ExamenParcial.Controllers
{
    
    public class AssignmentController : Controller
    {
        private readonly ILogger<AssignmentController> _logger;
        private readonly ApplicationDbContext _context;

        public AssignmentController(ILogger<AssignmentController> logger, ApplicationDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Asociar()
        {
        ViewBag.Players = new SelectList(_context.DbSetPlayer, "Id", "Nombre");
        ViewBag.Teams = new SelectList(_context.DbSetTeam, "Id", "Nombre");
        return View();
        }

        [HttpPost]
        public async Task<IActionResult> Asociar(int PlayerId, int TeamId)
        {
        var existe = await _context.DbSetAssignment.AnyAsync(a => a.PlayerId == PlayerId && a.TeamId == TeamId);
        if (!existe)

        {
        _context.Add(new Assignment { PlayerId = PlayerId, TeamId = TeamId });
        await _context.SaveChangesAsync();

        }

        return RedirectToAction("Listar");

        }

        public async Task<IActionResult> Listar()
        {
        var data = await _context.DbSetAssignment
                .Include(a => a.Player)
                .Include(a => a.Team)
                .ToListAsync();
                
        return View(data);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}   
