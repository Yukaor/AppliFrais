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

        public string Title { get; set; }

        public string Society { get; set; }

        public string City { get; set; }

        public DateTime Date { get; set; }

        public decimal Prix { get; set; }

        public virtual Etat Etat { get; set; }
    }
}
