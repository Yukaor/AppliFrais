using AppliFrais.EntityFramework.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.EntityFramework
{
    /// <summary>
    /// Classe qui contient les modèles
    /// </summary>
    public class BddContext : DbContext
    {
        public BddContext() : base("name=BddAppliFrais")
        {
            if(!Database.Exists())
            {
                Database.Create();
            }
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Metier> Metiers { get; set; }

        public DbSet<FicheFrais> FichesFrais { get; set; }

        public DbSet<NoteFrais> NotesFrais { get; set; }

        public DbSet<Etat> Etats { get; set; }
        
    }
}
