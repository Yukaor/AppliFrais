using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppliFrais.EntityFramework.Models;
using AppliFrais.EntityFramework.Services;

namespace AppliFrais.Services
{
    public class FicheFraisService : IFicheFraisService
    {

        private readonly IBddContext _IBddContext;

        public FicheFraisService(IBddContext iBddContext)
        {
            _IBddContext = iBddContext;
        }

        public void AddFicheFrais(FicheFrais ficheFrais)
        {
            _IBddContext.FichesFrais.Add(ficheFrais);
        }

        public void DeleteFicheFrais(FicheFrais ficheFrais)
        {
            _IBddContext.FichesFrais.Remove(ficheFrais);
        }

        public void EditFicheFrais(FicheFrais oldFicheFrais, FicheFrais newFicheFrais)
        {
            oldFicheFrais = newFicheFrais;
        }

        public FicheFrais GetFicheFrais(int id)
        {
            return _IBddContext.FichesFrais.FirstOrDefault(f => f.Id == id);
        }

        public List<FicheFrais> GetFichesFrais()
        {
            return _IBddContext.FichesFrais.ToList<FicheFrais>();
        }
    }
}