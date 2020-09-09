using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Entities
{
    public class LocacaoFilmes
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public int LocacaoId { get; set; }

        [ForeignKey("LocacaoId")]
        public virtual Locacao Locacao { get; set; }
        [ForeignKey("FilmeId")]
        public virtual Filme Filme { get; set; }
    }
}
