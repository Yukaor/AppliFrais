using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AppliFrais.Services;
using AppliFrais.ViewsModel;
using System.Security.Claims;
using System.Security.Principal;

namespace AppliFrais.Controllers
{
    public class ComptableController : Controller
    {
        private readonly IUserService _IUserService;
        private readonly IFicheFraisService _IFicheFraisService;
        private readonly INoteFraisService _INoteFraisService;
        private readonly IEtatService _IEtatService;
        private readonly ISaveService _ISaveService;

        public ComptableController(IUserService iUserService, IFicheFraisService iFicheFraisService, INoteFraisService iNoteFraisService, IEtatService iEtatService, ISaveService iSaveService)
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
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Comptable")
            {
                return RedirectToAction("Index", "Home");
            }

            var commerciaux = _IUserService.GetUsers("Commercial");
            return View(new IndexComptableViewModel { commerciaux = commerciaux});
        }

        public ActionResult FichesFrais(int Id)
        {

            var claimIdentity = User.Identity as ClaimsIdentity;
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Comptable")
            {
                return RedirectToAction("Index", "Home");
            }

            var fichesFrais = _IUserService.GetUser(Id).ListeFichesFrais;
            return View(new FichesFraisComptableViewModel { fichesFrais = fichesFrais });
        }

        public ActionResult NotesFrais(int ficheFraisId, int noteFraisId, int etatId)
        {

            var claimIdentity = User.Identity as ClaimsIdentity;
            if (claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value != "Comptable")
            {
                return RedirectToAction("Index", "Home");
            }

            if (noteFraisId >= 0)
            {
                var oldNoteFrais = _INoteFraisService.GetNoteFrais(noteFraisId);
                var newNoteFrais = oldNoteFrais;

                newNoteFrais.Etat = _IEtatService.GetEtat(etatId);
                _INoteFraisService.EditNoteFrais(oldNoteFrais, newNoteFrais);

                _ISaveService.Save();
            }
            else if (noteFraisId == -2)
            {
                var etatEnAttente = _IEtatService.GetEtat(2);
                var oldFicheFrais = _IFicheFraisService.GetFicheFrais(ficheFraisId);
                var newFicheFrais = oldFicheFrais;

                newFicheFrais.Valide = true;

                var notesFrais = newFicheFrais.ListeNotesFrais.Where(note => note.Etat.Label == "En attente").ToList();

                foreach(var note in notesFrais)
                {
                    var newNoteFrais = note;

                    newNoteFrais.Etat = etatEnAttente;

                    _INoteFraisService.EditNoteFrais(note, newNoteFrais);

                }

                _ISaveService.Save();

            }

            var ficheFrais = _IFicheFraisService.GetFicheFrais(ficheFraisId);

            return View(new NotesFraisComptableViewModel { ficheFrais = ficheFrais });
        }
    }
}