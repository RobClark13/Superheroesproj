using Microsoft.AspNetCore.Mvc;
using Superheroes.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Superheroes.Models;

namespace Superheroes.Controllers
{
    public class SuperheroController : Controller
    {
        private readonly ApplicationDbContext _context;
        public SuperheroController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var superheroes = _context.Superheroes;
            return View(superheroes);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Superhero superhero)
        {
            _context.Superheroes.Add(superhero);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var superheroDetails = _context.Superheroes.Find(id);
            return View(superheroDetails);
        }

      
        
    }
}
