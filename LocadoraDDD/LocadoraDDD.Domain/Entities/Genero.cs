using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Entities
{
    public class Genero
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCriacao { get; set; }
        public bool Ativo { get; set; }
    }
}
