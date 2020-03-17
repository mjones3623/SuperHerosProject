using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeros.Data;
using SuperHeros.Data.Migrations;
using SuperHeros.Models;

namespace SuperHeros.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext _context;
        public SuperHeroController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SuperHero
        public ActionResult Index()
        {
            var heroes = _context.SuperHeroes.ToList();
            return View(heroes);
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            var hero = _context.SuperHeroes.Where(i => i.Id == id);
            return View(hero);
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHero superHero = new SuperHero();
            return View(superHero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SuperHero superHero)
        {
            try
            {
                // TODO: Add insert logic here
                _context.SuperHeroes.Add(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            var hero = _context.SuperHeroes.Where(i => i.Id == id);
            return View(hero);
        }

        //POST: SuperHero/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add update logic here
                var hero = _context.SuperHeroes.Where(i => i.Id == id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        //GET: SuperHero/Delete/5
        public ActionResult Delete(int id)
        {
            var hero = _context.SuperHeroes.Where(i => i.Id == id);

            return View(hero);
        }

        //POST: SuperHero/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SuperHero superHero)
        {
            try
            {
                // TODO: Add delete logic here
                var hero = _context.SuperHeroes.Where(i => i.Id == id);
                _context.SuperHeroes.Remove(superHero);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}