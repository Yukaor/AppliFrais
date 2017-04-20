using AppliFrais.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.Services
{
    public interface IFicheFraisService
    {
        List<FicheFrais> GetFichesFrais();

        FicheFrais GetFicheFrais(int id);

        void AddFicheFrais(FicheFrais ficheFrais);

        void EditFicheFrais(FicheFrais oldFicheFrais, FicheFrais newFicheFrais);

        void DeleteFicheFrais(FicheFrais ficheFrais);
    }
}
