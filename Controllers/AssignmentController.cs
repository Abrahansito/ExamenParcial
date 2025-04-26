using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ExamenParcial.Controllers
{
    
    public class AssignmentController : Controller
    {
        private readonly ILogger<AssignmentController> _logger;

        public AssignmentController(ILogger<AssignmentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Asociar()
        {
        ViewBag.Players = new SelectList(_context.Players, "Id", "Nombre");
        ViewBag.Teams = new SelectList(_context.Teams, "Id", "Nombre");
        return View();
        }

        [HttpPost]
        public async Task<IActionResult> Asociar(int PlayerId, int TeamId)
        {
        var existe = await _context.Assignments.AnyAsync(a => a.PlayerId == PlayerId && a.TeamId == TeamId);
        if (!existe)

        {
        _context.Add(new Assignment { PlayerId = PlayerId, TeamId = TeamId });
        await _context.SaveChangesAsync();

        }

        return RedirectToAction("Listar");

        public async Task<IActionResult> Listar()
        {
        var data = await _context.Assignments
                .Include(a => a.Player)
                .Include(a => a.Team)
                .ToListAsync();
                
        return View(data);
        }

}























        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}