using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppliFrais.EntityFramework.Models
{
    public class NoteFrais
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; }

        public decimal Prix { get; set; }

        public Etat Etat { get; set; }
    }
}
