using SuperHeroes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();

        // GET: SuperHero (DONE)
        public ActionResult Index()
        {
            List<SuperHeroe> superheroList = context.SuperHeroeCharacters.ToList();
            return View(superheroList);
            
        }

        // GET: SuperHero/Details/5
        public ActionResult Details(int id)
        {
            
            {
                SuperHeroe superhero = context.SuperHeroeCharacters.Where(i => i.Id == id).Single();
                return View(superhero);
            }
            
        }

        // GET: SuperHero/Create
        public ActionResult Create()
        {
            SuperHeroe superhero = new SuperHeroe();
            
            return View(superhero);
        }

        // POST: SuperHero/Create
        [HttpPost]
        public ActionResult Create(SuperHeroe superHeroes)
        {
            try
            {
                // TODO: Add insert logic here

                context.SuperHeroeCharacters.Add(superHeroes);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperHero/Edit/5
        public ActionResult Edit(int id)
        {
            {
                //Superhero superhero = context.Superheroes.Where(i => i.Id == id).FirstOrDefault();
                SuperHeroe superhero = context.SuperHeroeCharacters.Find(id);
                if (superhero == null)
                {
                    return HttpNotFound();
                }
                return View(superhero);
            }
            return View();
        }

        // POST: SuperHero/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, SuperHeroe superhero)
        {
            try
            {
                var supereheroInDb = context.SuperHeroeCharacters.Where(s => s.Id == superhero.Id).SingleOrDefault();
                supereheroInDb.Name = superhero.Name;
                supereheroInDb.AlterEgo = superhero.AlterEgo;
                supereheroInDb.PrimaryAbility = superhero.PrimaryAbility;
                supereheroInDb.SecondaryAbility = superhero.SecondaryAbility;
                supereheroInDb.CatchPhrase = superhero.CatchPhrase;
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View("Index");
            }
        }

        // GET: SuperHero/Delete/5 (DONE)
        public ActionResult Delete(int id)
        {
            {
                SuperHeroe superhero = context.SuperHeroeCharacters.Find(id);
                if (superhero == null)
                {
                    return HttpNotFound();
                }
                return View(superhero);
            }
            
        }

        // POST: SuperHero/Delete/5 (DONE)
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                SuperHeroe superhero = context.SuperHeroeCharacters.Find(id);
                context.SuperHeroeCharacters.Remove(superhero);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}



