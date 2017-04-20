using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppliFrais.EntityFramework.Models;
using AppliFrais.EntityFramework.Services;

namespace AppliFrais.Services
{
    public class EtatService : IEtatService
    {

        private readonly IBddContext _IBddContext;

        public EtatService(IBddContext iBddContext)
        {
            _IBddContext = iBddContext;
        }

        public void AddEtat(Etat etat)
        {
            _IBddContext.Etats.Add(etat);
        }

        public void DeleteEtat(Etat etat)
        {
            _IBddContext.Etats.Remove(etat);
        }

        public void EditEtat(Etat oldEtat, Etat newEtat)
        {
            oldEtat = newEtat;
        }

        public Etat GetEtat(int id)
        {
            return _IBddContext.Etats.FirstOrDefault(e => e.Id == id);
        }

        public List<Etat> GetEtats()
        {
            return _IBddContext.Etats.ToList<Etat>();
        }
    }
}