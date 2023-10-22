using Gestion_Produit_MVC.Models;
using Gestion_Produit_MVC.Models.Repositories;
using Gestion_Produit_MVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Gestion_Produit_MVC.Controllers
{
    public class ProduitController : Controller
    {
        public IRepository<Famille> FamilleRepository { get;}
        public IRepository<Produit> ProduitRepository { get;}
        public ProduitController(IRepository<Produit> produitRepository, IRepository<Famille> familleRepository)
        {
            ProduitRepository = produitRepository;
            FamilleRepository = familleRepository;

        }
        public IActionResult Index()
        {
            var produits = ProduitRepository.Lister();
            return View(produits);
        }

        public IActionResult Details(int id)
        {
            var produit = ProduitRepository.ListerSelonId(id);
            return View(produit);
        }
        public IActionResult Create()
        {
            ProduitFamilleViewModel viewModel = new ProduitFamilleViewModel()
            {
                Familles = FamilleRepository.Lister(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(ProduitFamilleViewModel viewModel)
        {
            try
            {
                var produit = new Produit
                {
                    reference = viewModel.reference,
                    designation = viewModel.designation,
                    description = viewModel.description,
                    disponible = viewModel.disponible,
                    famille = new Famille
                    {
                        id = viewModel.FamilleId,
                        nom = FamilleRepository.ListerSelonId(viewModel.FamilleId).nom
                    }
                };
                ProduitRepository.Ajouter(produit);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public IActionResult Edit(int id)
        {
            var produit = ProduitRepository.ListerSelonId(id);
            ProduitFamilleViewModel viewModel = new ProduitFamilleViewModel
            {
                ProduitId = produit.id,
                reference = produit.reference,
                designation = produit.designation,
                description = produit.description,
                disponible = produit.disponible,
                FamilleId = produit.famille.id,
                Familles = FamilleRepository.Lister(),
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Edit(int id, ProduitFamilleViewModel viewModel)
        {
            try
            {
                var editProduit = new Produit
                {
                    id = id,
                    reference = viewModel.reference,
                    designation = viewModel.designation,
                    description = viewModel.description,
                    famille = new Famille
                    {
                        id = viewModel.FamilleId,
                        nom = FamilleRepository.ListerSelonId(viewModel.FamilleId).nom,
                    }
                };
                ProduitRepository.Modifier(id, editProduit);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var produit = ProduitRepository.ListerSelonId(id);
            return View(produit);
        }
        [HttpPost]
        public ActionResult Delete(int id, Produit produit)
        {
            try
            {
                ProduitRepository.Supprimer(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return View();
            }
        }

    }
}
