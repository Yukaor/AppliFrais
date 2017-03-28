using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.EntityFramework.Models
{
    /// <summary>
    /// Class User
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Nom { get; set; }

        public string Prenom { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public Metier Metier { get; set; }

    }
}
