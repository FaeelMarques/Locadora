using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Entities
{
    public class Locacao
    {
        public int Id { get; set; }
        public string CpfCliente { get; set; }
        public DateTime DataLocacao { get; set; }

        public virtual ICollection<Filme> ListaFilmes { get; set; }
    }
}
