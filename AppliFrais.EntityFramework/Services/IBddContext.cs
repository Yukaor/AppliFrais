using AppliFrais.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.EntityFramework.Services
{
    public interface IBddContext
    {
        DbSet<User> Users { get; set; }

        DbSet<FicheFrais> FichesFrais { get; set; }

        DbSet<NoteFrais> NotesFrais { get; set; }

        DbSet<Etat> Etats { get; set; }

        void MySaveChanges();
    }
}
