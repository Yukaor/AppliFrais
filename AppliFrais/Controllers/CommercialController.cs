using AppliFrais.EntityFramework.Models;
using AppliFrais.Services;
using AppliFrais.ViewsModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace AppliFrais.Controllers
{
    public class CommercialController : Controller
    {

        private readonly IUserService _IUserService;
        private readonly IFicheFraisService _IFicheFraisService;
        private readonly INoteFraisService _INoteFraisService;
        private readonly IEtatService _IEtatService;
        private readonly ISaveService _ISaveService;

        public CommercialController(IUserService iUserService, IFicheFraisService iFicheFraisService, INoteFraisService iNoteFraisService, IEtatService iEtatService, ISaveService iSaveService)
        {
            _IUserService = iUserService;
            _IFicheFraisService = iFicheFraisService;
            _INoteFraisService = iNoteFraisService;
            _IEtatService = iEtatService;
            _ISaveService = iSaveService;
        }
        public ActionResult Index()
        {
            var claimIdentity = User.Identity as ClaimsIdentity;
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Commercial")
            {
                return RedirectToAction("Index", "Home");
            }

            var fichesFrais = _IUserService.GetUser(Int32.Parse(claimIdentity.FindFirst(ClaimTypes.Surname).Value)).ListeFichesFrais;

            return View(new IndexCommercialViewModel { fichesFrais = fichesFrais });
        }

        public ActionResult AddFicheFrais()
        {
            var claimIdentity = User.Identity as ClaimsIdentity;
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Commercial")
            {
                return RedirectToAction("Index", "Home");
            }
            var fichesFrais = _IUserService.GetUser(Int32.Parse(claimIdentity.FindFirst(ClaimTypes.Surname).Value)).ListeFichesFrais;
            int count = 0;
            foreach(var ficheFrais in fichesFrais)
            {
                if (ficheFrais.Date.Month == DateTime.Now.Month && ficheFrais.Date.Year == DateTime.Now.Year)
                {
                    return RedirectToAction("NotesFrais", "Commercial", ficheFrais.Id);
                }

                count += 1;

                if (count == fichesFrais.Count)
                {
                    FicheFrais newFicheFrais = new FicheFrais
                    {
                        Date = DateTime.Now,
                        ListeNotesFrais = null,
                        Valide = false,
                        
                    };

                    _IUserService.GetUser(Int32.Parse(claimIdentity.FindFirst(ClaimTypes.Surname).Value)).ListeFichesFrais.Add(newFicheFrais);
                    _IFicheFraisService.AddFicheFrais(newFicheFrais);

                    _ISaveService.Save();

                    return RedirectToAction("NotesFrais", "Commercial", newFicheFrais.Id);

                }

            }
            return RedirectToAction("Index", "Commercial");
        }

        public ActionResult NotesFrais(int ficheFraisId)
        {
            var claimIdentity = User.Identity as ClaimsIdentity;
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Commercial")
            {
                return RedirectToAction("Index", "Home");
            }

            var ficheFrais = _IFicheFraisService.GetFicheFrais(ficheFraisId);

            return View(new NotesFraisCommercialViewModel { ficheFrais = ficheFrais });
        }
        
        public ActionResult AddNoteFrais()
        {
            var claimIdentity = User.Identity as ClaimsIdentity;
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Commercial")
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddNoteFrais(NoteFrais noteFrais)
        {

            var claimIdentity = User.Identity as ClaimsIdentity;
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Commercial")
            {
                return RedirectToAction("Index", "Home");
            }
            

            if (ModelState.IsValid)
            {

                var fichesFrais = _IUserService.GetUser(Int32.Parse(claimIdentity.FindFirst(ClaimTypes.Surname).Value)).ListeFichesFrais;
                FicheFrais goodFicheFrais = null;
                foreach (var ficheFrais in fichesFrais)
                {
                    if (ficheFrais.Date.Month == DateTime.Now.Month && ficheFrais.Date.Year == DateTime.Now.Year)
                    {
                        goodFicheFrais = ficheFrais;
                        break;
                    }
                    break;
                }
                
                noteFrais.Date = DateTime.Now;
                noteFrais.Etat = _IEtatService.GetEtat(1);

                goodFicheFrais.ListeNotesFrais.Add(noteFrais);

                _ISaveService.Save();

                return RedirectToAction("Index", "Commercial");
            }

            return View();
        }
    }
}