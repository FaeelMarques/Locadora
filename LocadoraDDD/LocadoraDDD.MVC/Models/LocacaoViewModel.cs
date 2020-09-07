using LocadoraDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocadoraDDD.MVC.Models
{
    public class LocacaoViewModel
    {
        public int Id { get; set; }
        public string CpfCliente { get; set; }
        public DateTime DataLocacao { get; set; }

        public virtual ICollection<Filme> ListaFilmes { get; set; }
    }
}