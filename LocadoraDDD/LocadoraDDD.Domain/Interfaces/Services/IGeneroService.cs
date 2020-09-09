using LocadoraDDD.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraDDD.Domain.Interfaces.Services
{
    public interface IGeneroService : IServiceBase<Genero>
    {
        IEnumerable<Genero> BuscarPorTitulo(string nome);
    }
}
