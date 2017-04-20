using AppliFrais.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.Services
{
    public interface IEtatService
    {
        List<Etat> GetEtats();

        Etat GetEtat(int id);

        void AddEtat(Etat etat);

        void EditEtat(Etat oldEtat, Etat newEtat);

        void DeleteEtat(Etat etat);
    }
}
