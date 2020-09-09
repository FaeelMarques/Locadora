using LocadoraDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Interfaces.Repositories
{
    public interface IFilmeRepository : IRepositoryBase<Filme>
    {
        IEnumerable<Filme> BuscarPorTitulo(string nome);
    }
}
