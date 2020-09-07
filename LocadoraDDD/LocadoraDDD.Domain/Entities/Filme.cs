using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Entities
{
    public class Filme
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }

        public int GeneroId { get; set; }

        public bool Ativo { get; set; }

        [ForeignKey("GeneroId")]
        public virtual Genero Genero { get; set; }
    }
}
