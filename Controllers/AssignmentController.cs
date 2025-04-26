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
        

        public AssignmentController(ILogger<AssignmentController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}