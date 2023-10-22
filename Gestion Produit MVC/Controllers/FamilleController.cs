using Gestion_Produit_MVC.Models;
using Gestion_Produit_MVC.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Produit_MVC.Controllers
{
    public class FamilleController : Controller
    {
        // Injection du service FamilleRepository
        public IRepository<Famille> Repository { get;}
        public FamilleController(IRepository<Famille> repository)
        {
            Repository = repository;
        }
        public IActionResult Index()
        {
            var familles = Repository.Lister();
            return View(familles);
        }
        public IActionResult Details(int id) { 
            var famille = Repository.ListerSelonId(id);
            return View(famille);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Famille famille)
        {
            try
            {
                Repository.Ajouter(famille);
                return RedirectToAction(nameof(Index));
            }catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var famille = Repository.ListerSelonId(id);
            return View(famille);
        }
        [HttpPost]
        public ActionResult Edit(int id, Famille famille)
        {
            try
            {
                Repository.Modifier(id,famille);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var famille = Repository.ListerSelonId(id);
            return View(famille);
        }
        [HttpPost]
        public ActionResult Delete(int id, Famille famille)
        {
            try
            {
                Repository.Supprimer(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }


    }
}
