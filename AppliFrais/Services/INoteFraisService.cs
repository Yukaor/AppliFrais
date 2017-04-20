using AppliFrais.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.Services
{
    public interface INoteFraisService
    {
        List<NoteFrais> GetNotesFrais();

        NoteFrais GetNoteFrais(int id);

        void AddNoteFrais(NoteFrais noteFrais);

        void EditNoteFrais(NoteFrais oldNoteFrais, NoteFrais newNoteFrais);

        void DeleteNoteFrais(NoteFrais noteFrais);
        
    }
}
