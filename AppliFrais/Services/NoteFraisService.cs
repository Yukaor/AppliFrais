using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AppliFrais.EntityFramework.Models;
using AppliFrais.EntityFramework.Services;

namespace AppliFrais.Services
{
    public class NoteFraisService : INoteFraisService
    {

        private readonly IBddContext _IBddContext;

        public NoteFraisService(IBddContext iBddContext)
        {
            _IBddContext = iBddContext;
        }

        public void AddNoteFrais(NoteFrais noteFrais)
        {
            _IBddContext.NotesFrais.Add(noteFrais);
        }

        public void DeleteNoteFrais(NoteFrais noteFrais)
        {
            _IBddContext.NotesFrais.Remove(noteFrais);
        }

        public void EditNoteFrais(NoteFrais oldNoteFrais, NoteFrais newNoteFrais)
        {
            oldNoteFrais = newNoteFrais;
        }

        public NoteFrais GetNoteFrais(int id)
        {
            return _IBddContext.NotesFrais.FirstOrDefault(n => n.Id == id);
        }

        public List<NoteFrais> GetNotesFrais()
        {
            return _IBddContext.NotesFrais.ToList<NoteFrais>();
        }
    }
}