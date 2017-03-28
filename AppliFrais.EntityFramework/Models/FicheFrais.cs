using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.EntityFramework.Models
{
    public class FicheFrais
    {
        [Key]
        public int Id { get; set; }

        public DateTimeOffset Date { get; set; }

        public bool Valide { get; set; }

        public List<NoteFrais> ListeNotesFrais { get; set; }
    }
}
